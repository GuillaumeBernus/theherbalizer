using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Domain.Handler
{
    /// <summary>
    /// Class OutputStreamGenerator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal static class OutputStreamGenerator<T>
    {
        /// <summary>
        /// Generates the output stream.
        /// </summary>
        /// <param name="list">The mower positions.</param>
        /// <returns>Stream.</returns>
        public static async Task<Stream> WriteListToStreamAsync(List<T> list)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            foreach (var item in list)
            {
                await writer.WriteLineAsync(item.ToString()).ConfigureAwait(false);
            }

            await writer.FlushAsync().ConfigureAwait(false);
            stream.Position = 0;
            return stream;
        }
    }
}