using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristAppBackend.Application.GpxFiles.Commands.UploadGpx;

namespace TouristAppBackend.Controllers
{
    [Route("api/gpx")]
    [ApiController]
    [EnableCors("My CORS policy")]
    //[Authorize]
    public class GpxController : BaseController
    {
        /// <summary>
        /// Copy file to directory
        /// </summary>
        /// <param name="command">gpx file</param>
        /// <returns>path to file</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromForm]CreateGpxCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
