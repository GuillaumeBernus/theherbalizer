using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Domain.Interface
{
    /// <summary>
    /// Interface ILawnApiClient
    /// </summary>
    public interface ILawnApiClient
    {
        /// <summary>
        /// Gets the mower positions asynchronous.
        /// </summary>
        /// <param name="lawn">The lawn.</param>
        /// <returns>Task&lt;List&lt;MowerPosition&gt;&gt;.</returns>
        Task<List<MowerPosition>> GetMowerPositionsAsync(Lawn lawn);
    }
}