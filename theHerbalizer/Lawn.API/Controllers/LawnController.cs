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
    [ApiController]
    [Route("[controller]")]
    public class LawnController : ControllerBase
    {
   

        private readonly ILogger<LawnController> _logger;

        public LawnController(ILogger<LawnController> logger)
        {
            _logger = logger;
        }

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
