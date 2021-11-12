using LawnFile.Domain.Extensions;
using LawnFile.Domain.Interface;
using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LawnFile.Domain.Handler
{
    /// <summary>
    /// Class LawnFileHandler.
    /// Implements the <see cref="LawnFile.Domain.Interface.ILawnFileHandler" />
    /// </summary>
    /// <seealso cref="LawnFile.Domain.Interface.ILawnFileHandler" />
    public class LawnFileHandler : ILawnFileHandler
    {

        private readonly ILawnApiClient _lawnAPIClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnFileHandler" /> class.
        /// </summary>
        public LawnFileHandler(ILawnApiClient lawnAPIClient)
        {
            _lawnAPIClient = lawnAPIClient ?? throw new ArgumentNullException(nameof(lawnAPIClient)); ;
        }

        /// <summary>
        /// Handle as an asynchronous operation.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>A Task&lt;Lawn&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception">Empty file</exception>
        /// <exception cref="System.Exception">First Line is not a lawn description</exception>
        /// <exception cref="System.Exception">Wrong mower description</exception>
        public async Task<Stream > HandleAsync(string filePath)
        {
            var lawnDescription = await GetLawnDescriptionAsync(filePath).ConfigureAwait(false);

            var lawn = Lawn.FromLawnDescription(lawnDescription);


            var mowerPositions = await _lawnAPIClient.TreatLawnDescriptionAsync(lawn).ConfigureAwait(false);




            return await TreatPositions(mowerPositions).ConfigureAwait(false);
        }

        private static async Task<Stream> TreatPositions(List<MowerPosition> mowerPositions)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            foreach (var position in mowerPositions)
            {
                await writer.WriteLineAsync(position.ToString()).ConfigureAwait(false);
            }

            await writer.FlushAsync().ConfigureAwait(false);
            stream.Position = 0;
            return stream;
        }



        private async Task<LawnDescription> GetLawnDescriptionAsync(string filePath)
        {
            using StreamReader srIn = new StreamReader(filePath, true);

            if (srIn.EndOfStream)
            {
                throw new Exception("Empty file");
            }

            var lawnSize = await srIn.ReadLineAsync().ConfigureAwait(false);

            if (!lawnSize.IsLawnDescription())
            {
                throw new Exception("First Line is not a lawn description");
            }

            var mowerDescriptions = new List<MowerDescription>();
            while (!srIn.EndOfStream)
            {
                var mowerDescription = await srIn.ExtractMowerDescriptionAsync().ConfigureAwait(false);

                if (!mowerDescription.Check())
                {
                    throw new Exception("Wrong mower description");
                }
                mowerDescriptions.Add(mowerDescription);
            }

            return new LawnDescription
            {
                UpperRightCorner = lawnSize,
                MowerDescriptions = mowerDescriptions
            };
        }



    }
}