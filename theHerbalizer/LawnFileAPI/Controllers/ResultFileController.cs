using LawnFile.Domain.Interface;
using LawnFile.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LawnFile.API.Controllers
{
    /// <summary>
    /// Class ResultFileController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ResultFileController : ControllerBase
    {


        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ResultFileController> _logger;

        /// <summary>
        /// The handler
        /// </summary>
        private readonly IMowerPositionsHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultFileController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="handler">The handler.</param>
        /// <exception cref="System.ArgumentNullException">logger</exception>
        /// <exception cref="System.ArgumentNullException">handler</exception>
        public ResultFileController(ILogger<ResultFileController> logger, IMowerPositionsHandler handler)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _handler=handler??throw new ArgumentNullException(nameof(handler));
        }



        /// <summary>
        /// Post as an asynchronous operation.
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <returns>A Task&lt;ActionResult`1&gt; representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync(List<MowerPosition> positions)
            {
                Stream stream = await _handler.HandleAsync(positions).ConfigureAwait(false);
                string mimeType = Constants.ResultFileMimeType;
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = "Positions.txt"
            };
    
        }


    }
}
