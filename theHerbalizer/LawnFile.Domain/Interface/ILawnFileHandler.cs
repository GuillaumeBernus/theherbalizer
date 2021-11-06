using LawnFile.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Domain.Interface
{
    public interface ILawnFileHandler
    {
        Task<Lawn> HandleAsync(string filePath);
    }
}
