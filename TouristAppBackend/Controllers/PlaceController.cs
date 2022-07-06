using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TouristAppBackend.Application.Places.Commands.CreatePlace;
using TouristAppBackend.Application.Places.Commands.DeletePlace;
using TouristAppBackend.Application.Places.Commands.UpdatePlace;
using TouristAppBackend.Application.Places.Queries.GetAllPlaces;
using TouristAppBackend.Application.Places.Queries.GetPlaceDetail;
using TouristAppBackend.Application.Places.Queries.GetPlaceForUpdate;

namespace TouristAppBackend.Controllers
{
    [Route("api/places")]
    [ApiController]
    [EnableCors("My CORS policy")]
    //[Authorize]
    public class PlaceController : BaseController
    {
        //TODO update comments

        ///// <summary>
        ///// Returns places by id
        ///// </summary>
        ///// <param name="id">PlaceId</param>
        ///// <returns>Place by id</returns>
        ///// 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PlaceDetailVm>> GetDetails(int id)
        {
            PlaceDetailVm vm = await Mediator.Send(new GetPlaceDetailQuery(id) );

            return vm;
        }

        /// <summary>
        /// Returns all places
        /// </summary>
        /// <returns>List of place view models</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PlacesVm>> GetAll([FromQuery] int quantity, string SearchString, string AscDesc, DateTime? from, DateTime? to)
        {
            PlacesVm vm = await Mediator.Send(new PlacesQuery(quantity, SearchString, AscDesc, from, to));

            return vm;
        }

        /// <summary>
        /// Returns places by id
        /// </summary>
        /// <param name="id">PlaceId</param>
        /// <returns>Place by id</returns>
        /// 
        [HttpGet("{id}/forupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetPlaceForUpdateVm>> GetPlaceForUpdate(int id)
        {
            GetPlaceForUpdateVm vm = await Mediator.Send(new GetPlaceForUpdateQuery() { PlaceId = id });

            return vm;
        }

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
        public async Task<IActionResult> Create(CreatePlaceCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Updates place
        /// </summary>
        /// <param name="command">UpdatePlaceCommand object, with place id and connected coordinates id</param>
        /// <returns>Updated place</returns>
        /// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(UpdatePlaceCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }


        /// <summary>
        /// Deletes place by id
        /// </summary>
        /// <param name="command">PlaceId</param>
        /// <returns>Success</returns>
        ///  
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(DeletePlaceCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }


        
    }
}
