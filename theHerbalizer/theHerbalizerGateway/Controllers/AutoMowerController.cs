using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using theHerbalizerGateway.Services;

namespace theHerbalizerGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoMowerController : ControllerBase
    {
        private readonly ILogger<AutoMowerController> _logger;
        private readonly ILawnFileService _lawnFileService;
        public AutoMowerController(ILogger<AutoMowerController> logger, ILawnFileService lawnFileService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _lawnFileService = lawnFileService ?? throw new ArgumentNullException(nameof(lawnFileService));
        }

        [HttpPost]
        public async Task<ActionResult<Stream>> PostAsync(IFormFile formFile)
        {

            var stream=await _lawnFileService.TreatFileAsync(formFile).ConfigureAwait(false);
            return Ok(stream);
        }
    }
}