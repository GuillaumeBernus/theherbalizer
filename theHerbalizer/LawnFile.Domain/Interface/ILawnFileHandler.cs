using LawnFile.Domain.Model;
using System.IO;
using System.Threading.Tasks;

namespace LawnFile.Domain.Interface
{
    /// <summary>
    /// Interface ILawnFileHandler
    /// </summary>
    public interface ILawnFileHandler
    {
        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Task&lt;Lawn&gt;.</returns>
        Task<Stream> HandleAsync(string filePath);
    }
}