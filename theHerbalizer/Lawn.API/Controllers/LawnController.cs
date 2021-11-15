using Lawn.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MowerEngine.Exceptions;
using MowerEngine.Models;
using System.Collections.Generic;

namespace Lawn.API.Controllers
{
    /// <summary>
    /// Controller that handles the lawn
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LawnController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<LawnController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LawnController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LawnController(ILogger<LawnController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Posts the specified lawn.
        /// </summary>
        /// <param name="model">a lawn description</param>
        /// <returns>the position of the different mowers of the lawn</returns>
        [HttpPost]
        [ProducesResponseType(typeof(List<MowerPosition>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<MowerPosition>> Post([FromBody] LawnCommand model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var lawn = LawnCommandAssembler.ToLawn(model);
            List<MowerPosition> positions;
            try
            {
                positions = lawn.RunMowers();
            }
            catch (InvalidMoveDescriptionException e)
            {
                _logger.LogError(e, "Error in LawnController.Post");
                return BadRequest(e);
            }
            catch (InvalidLawnException e)
            {
                _logger.LogError(e, "Error in LawnController.Post");
                return BadRequest(e);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Error in LawnController.Post");
                throw;
            }

            return Ok(positions);
        }
    }
}