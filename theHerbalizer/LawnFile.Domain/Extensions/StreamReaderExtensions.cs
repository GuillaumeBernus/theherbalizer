using LawnFile.Domain.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LawnFile.Domain.Extensions
{
    /// <summary>
    /// Class StreamReaderExtensions.
    /// </summary>
    internal static class StreamReaderExtensions
    {
        /// <summary>
        /// Extract mower description as an asynchronous operation.
        /// </summary>
        /// <param name="sr">The sr.</param>
        /// <returns>A Task&lt;MowerDescription&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception">No SecondLine</exception>
        public static async Task<MowerDescription> ExtractMowerDescriptionAsync(this StreamReader sr)
        {
            var mowerDescription = new MowerDescription();
            mowerDescription.StartPosition = await sr.ReadLineAsync().ConfigureAwait(false);
            if (sr.EndOfStream)
            {
                throw new Exception("No SecondLine");
            }
            mowerDescription.Route = await sr.ReadLineAsync().ConfigureAwait(false);
            return mowerDescription;
        }
    }
}