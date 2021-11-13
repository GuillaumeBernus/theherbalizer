using LawnFile.Domain.Extensions;
using LawnFile.Domain.Interface;
using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
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
        public async Task<Stream> HandleAsync(string filePath)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var lawn = await GetLawnAsync(filePath).ConfigureAwait(false);
            sw.Stop();
            long ms1 = sw.ElapsedMilliseconds;
            sw.Restart();

            var mowerPositions = await _lawnAPIClient.TreatLawnDescriptionAsync(lawn).ConfigureAwait(false);
            sw.Stop();
            long ms2 = sw.ElapsedMilliseconds;
            sw.Restart();

            var res = await TreatPositions(mowerPositions).ConfigureAwait(false);
            sw.Stop();
            long ms3 = sw.ElapsedMilliseconds;

            return res;
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
            Stopwatch sw0 = new Stopwatch();
            sw0.Start();
            string mowers = await srIn.ReadToEndAsync().ConfigureAwait(false);

            var mowerDescriptions = ExtractMowerDescriptions(mowers);

            sw0.Stop();
            long ms = sw0.ElapsedMilliseconds;
            return new LawnDescription
            {
                UpperRightCorner = lawnSize,
                MowerDescriptions = mowerDescriptions
            };
        }

        private async Task<Lawn> GetLawnAsync(string filePath)
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
            Stopwatch sw0 = new Stopwatch();
            sw0.Start();
            string mowerDescriptions = await srIn.ReadToEndAsync().ConfigureAwait(false);

            var mowers = ExtractMowers(mowerDescriptions);

            sw0.Stop();
            long ms = sw0.ElapsedMilliseconds;
            return new Lawn
            {
                UpperRigthCorner = PointParser.Parse(lawnSize),
                Mowers = mowers
            };
        }

        private List<MowerDescription> ExtractMowerDescriptions(string source)
        {
            var lines = source.Split("\r\n");
            var count = lines.Length;
            MowerDescription[] outputArray = new MowerDescription[count > 1 ? count / 2 : 1];

            var loopEnd = count - 1;

            var waitHandle = new ManualResetEvent(false);
            int counter = 0;

            Parallel.For(0, loopEnd, index =>
            {
                if (index % 2 == 0)
                {
                    var outputIndex = index / 2;
                    outputArray[outputIndex] = new MowerDescription()
                    {
                        StartPosition = lines[index],
                        Route = lines[index + 1]
                    };
                }

                if (Interlocked.Increment(ref counter) == loopEnd - 1)
                {
                    waitHandle.Set();
                }
            });

            waitHandle.WaitOne();

            return outputArray.ToList();
        }

        private List<Mower> ExtractMowers(string source)
        {
            var lines = source.Split("\r\n");
            var count = lines.Length;
            Mower[] outputArray = new Mower[count > 1 ? count / 2 : 1];

            var loopEnd = count - 1;

            var waitHandle = new ManualResetEvent(false);
            int counter = 0;

            Parallel.For(0, loopEnd, index =>
            {
                if (index % 2 == 0)
                {
                    var outputIndex = index / 2;
                    outputArray[outputIndex] = MowerParser.FromMowerDescription(new MowerDescription()
                    {
                        StartPosition = lines[index],
                        Route = lines[index + 1]
                    });
                }

                if (Interlocked.Increment(ref counter) == loopEnd - 1)
                {
                    waitHandle.Set();
                }
            });

            waitHandle.WaitOne();

            return outputArray.ToList();
        }
    }
}