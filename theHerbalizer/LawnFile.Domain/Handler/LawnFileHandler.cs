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
            _lawnAPIClient = lawnAPIClient ?? throw new ArgumentNullException(nameof(lawnAPIClient));
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

            var lawn = await LawnExtractor.GetLawnAsync(filePath).ConfigureAwait(false);
            sw.Stop();
            long ms1 = sw.ElapsedMilliseconds;
            sw.Restart();

            var mowerPositions = await _lawnAPIClient.GetMowerPositionsAsync(lawn).ConfigureAwait(false);
            sw.Stop();
            long ms2 = sw.ElapsedMilliseconds;
            sw.Restart();

            var res = await OutputStreamGenerator<MowerPosition>.WriteListToStreamAsync(mowerPositions).ConfigureAwait(false);
            sw.Stop();
            long ms3 = sw.ElapsedMilliseconds;

            return res;
        }
    }
}