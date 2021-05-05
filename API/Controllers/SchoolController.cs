using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Domain;
using API.Infrastructure;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;

        public SchoolController(ISchoolService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get class summary
        /// </summary>
        /// <param name="className">Name of class</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        [HttpGet("class/{className}")]
        public async Task<ActionResult<IEnumerable<SchoolClass>>> Get(string className, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return StatusCode(0);
            var result = await _service.GetAsync(className, token).ConfigureAwait(false);
            if (result.Success) return Ok(result.Data);
            return result.Cause switch
            {
                ServiceResponse<SchoolClass>.CauseEnum.NOT_FOUND => NotFound(result.Data),
                ServiceResponse<SchoolClass>.CauseEnum.BAD_REQUEST => BadRequest(result.Message),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

    }
}
