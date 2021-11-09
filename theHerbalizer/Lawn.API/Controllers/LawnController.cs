using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MowerEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lawn.API.Controllers
{
    /// <summary>
    /// Controller that handles the lawn 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LawnController : ControllerBase
    {
   

        private readonly ILogger<LawnController> _logger;

        public LawnController(ILogger<LawnController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lawn">a lawn description</param>
        /// <returns>the position of the different mowers of the lawn</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       
        public ActionResult<IEnumerable<MowerPosition>> Post([FromBody] MowerEngine.Models.Lawn lawn)
        {
            return Ok(lawn.RunMowers());
           
        }
    }
}
