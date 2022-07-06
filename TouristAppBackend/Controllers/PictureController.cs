using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristAppBackend.Application.Images.Commands.UploadImage;
namespace TouristAppBackend.Controllers
{
    [Route("api/picture")]
    [ApiController]
    [EnableCors("My CORS policy")]
    //[Authorize]
    public class PictureController : BaseController
    {
        /// <summary>
        /// Creates new place, need to provide user id (visitor Id) that creates place
        /// </summary>
        /// <param name="command">CreatePlaceCommand object, coordinates must be provided from frontend</param>
        /// <returns>Created place Id</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromForm]CreateImageCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
