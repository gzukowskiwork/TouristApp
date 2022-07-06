using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristAppBackend.Application.Users.Commands.CreateUser;
using TouristAppBackend.Application.Users.Commands.DeleteUser;
using TouristAppBackend.Application.Users.Commands.UpdateUser;
using TouristAppBackend.Application.Users.Queries.GetAllUsers;
using TouristAppBackend.Application.Users.Queries.GetUserDetail;
using TouristAppBackend.Application.Users.Queries.GetUserForUpdate;

namespace TouristAppBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [EnableCors("My CORS policy")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>List of users</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsersVm>> GetAll()
        {
            UsersVm vm = await Mediator.Send(new UsersQuery());

            return vm;
        }

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User by id</returns>
        /// 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDetailVm>> GetDetail(int id)
        {
            UserDetailVm vm = await Mediator.Send(new GetUserDetailQuery() { UserId = id });

            return vm;
        }

        /// <summary>
        /// Returns user by id for update
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User by id</returns>
        /// 
        [HttpGet("{id}/forupdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserDetailForUpdateVm>> GetDetailForUpdate(int id)
        {
            GetUserDetailForUpdateVm vm = await Mediator.Send(new GetUserDetailForUpdataQuery() { UserId = id });

            return vm;
        }

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="command">CreateUserCommand object</param>
        /// <returns>Created place Id</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="command">UpdateUserCommand object</param>
        /// <returns>Updated place</returns>
        /// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Deletes user by id
        /// </summary>
        /// <param name="command">UserId</param>
        /// <returns>Success</returns>
        ///  
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
