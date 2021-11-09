using LawnFile.Domain.Interface;
using LawnFile.Domain.Model;
using LawnFile.API.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LawnFile.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LawnFileController : ControllerBase
    {
        private readonly ILogger<LawnFileController> _logger;

        private readonly InputFileConfiguration _inputFileConfiguration;
        private readonly ILawnFileHandler _lawnFileHandler;

        public LawnFileController(ILogger<LawnFileController> logger, IOptions<InputFileConfiguration> inputFileConfiguration, ILawnFileHandler lawnFileHandler)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _inputFileConfiguration = inputFileConfiguration?.Value ?? throw new ArgumentNullException(nameof(inputFileConfiguration));
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


            var filePath = Path.Combine(@"c:\TMP\theHerbalizer\",//_config["StoredFilesPath"],
                Path.GetRandomFileName());

            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }
            var lawn = await _lawnFileHandler.HandleAsync(filePath);

            return Ok(lawn);
        }

        private bool CheckFile(IFormFile formFile)
        {
            if (formFile.Length <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
