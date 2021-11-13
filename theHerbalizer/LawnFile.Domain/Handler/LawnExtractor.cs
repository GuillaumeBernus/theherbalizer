using LawnFile.Domain.Extensions;
using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawnFile.Domain.Handler
{
    /// <summary>
    /// Class LawnExtractor.
    /// </summary>
    internal static class LawnExtractor
    {
        /// <summary>
        /// Get lawn as an asynchronous operation.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>A Task&lt;Lawn&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="LawnFile.Domain.InvalidPointDescriptionException">Invalid UpperRigthCorner</exception>
        /// <exception cref="System.Exception">Empty file</exception>
        /// <exception cref="System.Exception">First Line is not a lawn description</exception>
        public static async Task<Lawn> GetLawnAsync(string filePath)
        {
            using StreamReader srIn = new StreamReader(filePath, true);

            if (srIn.EndOfStream)
            {
                throw new FileNotFoundException();
            }

            var lawnUpperRigthCorner = await srIn.ReadLineAsync().ConfigureAwait(false);

            if (!lawnUpperRigthCorner.IsPointDescription())
            {
                throw new InvalidPointDescriptionException("Invalid UpperRigthCorner");
            }

            string mowerDescriptions = await srIn.ReadToEndAsync().ConfigureAwait(false);

            var mowers = ExtractMowers(mowerDescriptions);

            return new Lawn
            {
                UpperRigthCorner = PointParser.Parse(lawnUpperRigthCorner),
                Mowers = mowers
            };
        }

        /// <summary>
        /// Extracts the mowers.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>List&lt;Mower&gt;.</returns>
        private static List<Mower> ExtractMowers(string source)
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
                    var position = lines[index];
                    var route = lines[index + 1];
                    outputArray[outputIndex] = MowerParser.Parse(position, route);
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