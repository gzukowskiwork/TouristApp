using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TouristAppBackend.Application.Tracks.Commands.CreateTrack;
using TouristAppBackend.Application.Tracks.Queries.GetAllTracks;
using TouristAppBackend.Application.Tracks.Queries.GetTrackDetail;

namespace TouristAppBackend.Controllers
{
    [Route("api/track")]
    [ApiController]
    [EnableCors("My CORS policy")]
    //[Authorize]
    public class TrackController : BaseController
    {
        /// <summary>
        /// Returns all tracks
        /// </summary>
        /// <returns>List of tracks view models</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TrackVm>> GetAll([FromQuery] int quantity, string SearchString, string AscDesc, DateTime? from, DateTime? to)
        {
            TrackVm vm = await Mediator.Send(new TrackQuery(quantity, SearchString, AscDesc, from, to));

            return vm;
        }

        /// <summary>
        /// Returns all tracks
        /// </summary>
        /// <returns>List of tracks view models</returns>
        /// 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetTrackDetailVm>> GetById(int id)
        {
            GetTrackDetailVm vm = await Mediator.Send(new GetTrackDetailQuery { TrackId = id });

            return vm;
        }

        /// <summary>
        /// Creates track with coordinates
        /// </summary>
        /// <returns>Boolean value</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateTrackCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
