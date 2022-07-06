using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristAppBackend.Application.Address.Queries.GetAddress;
using TouristAppBackend.Application.Address.Queries.GetAllAddresses;

namespace TouristAppBackend.Controllers
{
    [Route("api/address")]
    [ApiController]
    [EnableCors("My CORS policy")]
    [Authorize]
    public class AddressController : BaseController
    {
        /// <summary>
        /// Returns address by id
        /// </summary>
        /// <param name="id">Address id</param>
        /// <returns>Address by id</returns>
        /// 
        //[Authorize(Roles ="Administrator")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAddressDetailsVm>> GetDetails(int id)
        {
            GetAddressDetailsVm vm = await Mediator.Send(new GetAddressQuery { AddressId = id });

            return vm;
        }

        /// <summary>
        /// Returns all Addresses
        /// </summary>
        /// <returns>Returns all Addresses</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAllAddressesVm>> GetAll()
        {
            GetAllAddressesVm vm = await Mediator.Send(new GetAllAddressesQuery());

            return vm;
        }
    }
}
