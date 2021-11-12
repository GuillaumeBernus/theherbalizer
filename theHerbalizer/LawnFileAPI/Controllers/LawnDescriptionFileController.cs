using LawnFile.API.Configuration;
using LawnFile.Domain.Interface;
using LawnFile.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LawnFile.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LawnDescriptionFileController : ControllerBase
    {
        private readonly ILogger<LawnDescriptionFileController> _logger;

        private readonly InputFileConfiguration _inputFileConfiguration;
        private readonly FileTreatmentConfiguration _fileTreatmentConfiguration;
        private readonly ILawnFileHandler _lawnFileHandler;

        public LawnDescriptionFileController(ILogger<LawnDescriptionFileController> logger, IOptions<InputFileConfiguration> inputFileConfiguration
           , IOptions<FileTreatmentConfiguration> fileTreatmentConfiguration
            , ILawnFileHandler lawnFileHandler)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _inputFileConfiguration = inputFileConfiguration?.Value ?? throw new ArgumentNullException(nameof(inputFileConfiguration));
            _fileTreatmentConfiguration = fileTreatmentConfiguration?.Value ?? throw new ArgumentNullException(nameof(fileTreatmentConfiguration));
            _lawnFileHandler = lawnFileHandler ?? throw new ArgumentNullException(nameof(lawnFileHandler));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Lawn>> PostAsync(IFormFile formFile)
        {
            if (!CheckFile(formFile))
            {
                return BadRequest();
            }
            string filePath = await CopyFile(formFile).ConfigureAwait(false);
            try
            {
                var lawn = await _lawnFileHandler.HandleAsync(filePath);
                return Ok(lawn);
            }
            finally
            {
                System.IO.File.Delete(filePath);
            }
        }

        private async Task<string> CopyFile(IFormFile formFile)
        {
            var filePath = Path.Combine(_fileTreatmentConfiguration.TemporaryFileDirectoryPath,
                Path.GetRandomFileName());

            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            return filePath;
        }

        private bool CheckFile(IFormFile formFile)
        {
            if (formFile.Length <= 0)
            {
                return false;
            }

            if (formFile.Length > _inputFileConfiguration.MaxSizeOctets)
            {
                return false;
            }

            if (!_inputFileConfiguration.AllowedExtensions.Contains(Path.GetExtension(formFile.FileName)))
            {
                return false;
            }

            return true;
        }
    }
}