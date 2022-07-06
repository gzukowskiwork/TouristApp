using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristAppBackend.Application.ForecastPlaces.Commands.CreateForecastPlace;
using TouristAppBackend.Application.ForecastPlaces.Commands.DeleteForecast;
using TouristAppBackend.Application.ForecastPlaces.Commands.UpdateForecastPlace;
using TouristAppBackend.Application.ForecastPlaces.Queries.GetAllForecasts;
using TouristAppBackend.Application.ForecastPlaces.Queries.GetForecastDetail;

namespace TouristAppBackend.Controllers
{
    [Route("api/forecast")]
    [ApiController]
    [EnableCors("My CORS policy")]
    public class ForecastController : BaseController
    {
        /// <summary>
        /// Creates new forecast place, need to provide user id that creates place
        /// </summary>
        /// <param name="command">CreateForecastCommand object, coordinates must be provided from frontend</param>
        /// <returns>Created forecast place Id</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateForecastCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Returns all forecasts
        /// </summary>
        /// <returns>List of forecast view models</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ForecastVm>> GetAll()
        {
            ForecastVm vm = await Mediator.Send(new ForecastQuery());

            return vm;
        }

        /// <summary>
        /// Returns forecasts by id
        /// </summary>
        /// <param name="id">PlaceId</param>
        /// <returns>Place by id</returns>
        /// 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetForecastDetailVm>> GetDetails(int id)
        {
            GetForecastDetailVm vm = await Mediator.Send(new GetForecastDetailQuery { ForecastId = id });

            return vm;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetForecastDetailVm>> Update(UpdateForecastCommand command)
        {
            var resultm = await Mediator.Send(command);

            return Ok(resultm);
        }

        /// <summary>
        /// Deletes forecast by id
        /// </summary>
        /// <param name="command">ForecastId</param>
        /// <returns>Success</returns>
        ///  
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(DeleteForecastCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
