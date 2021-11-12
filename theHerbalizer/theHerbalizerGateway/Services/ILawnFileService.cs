using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace theHerbalizerGateway.Services
{
    public interface ILawnFileService
    {
        Task<Stream> TreatFileAsync(IFormFile formFile);
    }
}
