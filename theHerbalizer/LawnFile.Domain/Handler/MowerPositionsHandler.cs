using LawnFile.Domain.Interface;
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
    /// Class MowerPositionsHandler.
    /// Implements the <see cref="LawnFile.Domain.Interface.IMowerPositionsHandler" />
    /// </summary>
    /// <seealso cref="LawnFile.Domain.Interface.IMowerPositionsHandler" />
    public class MowerPositionsHandler : IMowerPositionsHandler
    {
        /// <summary>
        /// Handle as an asynchronous operation.
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <returns>A Task&lt;Stream&gt; representing the asynchronous operation.</returns>
        public async Task<Stream> HandleAsync(List<MowerPosition> positions)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            positions.ForEach(async(p) => await writer.WriteLineAsync(p.ToString()).ConfigureAwait(false));
            await writer.FlushAsync().ConfigureAwait(false);
            stream.Position = 0;
            return stream;
        }


    }
}
