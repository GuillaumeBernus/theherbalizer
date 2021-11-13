using LawnFile.API.Configuration;
using LawnFile.Domain;
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
    /// <summary>
    /// Class LawnDescriptionFileController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class LawnDescriptionFileController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<LawnDescriptionFileController> _logger;

        /// <summary>
        /// The input file configuration
        /// </summary>
        private readonly InputFileConfiguration _inputFileConfiguration;

        /// <summary>
        /// The file treatment configuration
        /// </summary>
        private readonly FileTreatmentConfiguration _fileTreatmentConfiguration;

        /// <summary>
        /// The lawn file handler
        /// </summary>
        private readonly ILawnFileHandler _lawnFileHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnDescriptionFileController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="inputFileConfiguration">The input file configuration.</param>
        /// <param name="fileTreatmentConfiguration">The file treatment configuration.</param>
        /// <param name="lawnFileHandler">The lawn file handler.</param>
        /// <exception cref="System.ArgumentNullException">logger</exception>
        /// <exception cref="System.ArgumentNullException">inputFileConfiguration</exception>
        /// <exception cref="System.ArgumentNullException">fileTreatmentConfiguration</exception>
        /// <exception cref="System.ArgumentNullException">lawnFileHandler</exception>
        public LawnDescriptionFileController(ILogger<LawnDescriptionFileController> logger, IOptions<InputFileConfiguration> inputFileConfiguration
           , IOptions<FileTreatmentConfiguration> fileTreatmentConfiguration
            , ILawnFileHandler lawnFileHandler)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _inputFileConfiguration = inputFileConfiguration?.Value ?? throw new ArgumentNullException(nameof(inputFileConfiguration));
            _fileTreatmentConfiguration = fileTreatmentConfiguration?.Value ?? throw new ArgumentNullException(nameof(fileTreatmentConfiguration));
            _lawnFileHandler = lawnFileHandler ?? throw new ArgumentNullException(nameof(lawnFileHandler));
        }

        /// <summary>
        /// Post as an asynchronous operation.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <returns>A Task&lt;ActionResult`1&gt; representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync(IFormFile formFile)
        {
            if (!CheckFile(formFile))
            {
                return BadRequest();
            }
            string filePath = await CopyFileAsync(formFile).ConfigureAwait(false);
            try
            {
                Stream stream = await _lawnFileHandler.HandleAsync(filePath).ConfigureAwait(false);
                string mimeType = Constants.ResultFileMimeType;
                return new FileStreamResult(stream, mimeType)
                {
                    FileDownloadName = _fileTreatmentConfiguration.OutputFileName
                };
            }
            catch (InvalidDescriptionException e)
            {
                _logger.LogError(e, "Error in LawnDescriptionFileController PostAsync");
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in LawnDescriptionFileController PostAsync");
                throw;
            }
            finally
            {
                System.IO.File.Delete(filePath);
            }
        }

        /// <summary>
        /// Copy file as an asynchronous operation.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <returns>A Task&lt;System.String&gt; representing the asynchronous operation.</returns>
        private async Task<string> CopyFileAsync(IFormFile formFile)
        {
            var filePath = Path.Combine(_fileTreatmentConfiguration.TemporaryFileDirectoryPath,
                Path.GetRandomFileName());

            using var stream = System.IO.File.Create(filePath);

            await formFile.CopyToAsync(stream).ConfigureAwait(false);

            return filePath;
        }

        /// <summary>
        /// Checks the file.
        /// </summary>
        /// <param name="formFile">The form file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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