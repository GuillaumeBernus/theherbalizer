using LawnFile.Domain.Model;
using System.Threading.Tasks;

namespace LawnFile.Domain.Interface
{
    public interface ILawnFileHandler
    {
        Task<Lawn> HandleAsync(string filePath);
    }
}