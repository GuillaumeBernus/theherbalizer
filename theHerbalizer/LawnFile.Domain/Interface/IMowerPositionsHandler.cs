using LawnFile.Domain.Handler;
using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Domain.Interface
{
    /// <summary>
    /// Interface IMowerPositionsHandler
    /// </summary>
    public interface IMowerPositionsHandler
    {
        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <returns>Task&lt;Stream&gt;.</returns>
        Task<Stream> HandleAsync(List<MowerPosition> positions);
    }
}
