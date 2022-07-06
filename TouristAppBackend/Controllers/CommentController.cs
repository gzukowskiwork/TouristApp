using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristAppBackend.Application.Comments.Commands.Create;
using TouristAppBackend.Application.Comments.Commands.Create.CreatePictureComment;
using TouristAppBackend.Application.Comments.Commands.Create.CreateReplyComment;
using TouristAppBackend.Application.Comments.Commands.Create.CreateTrackComment;
using TouristAppBackend.Application.Comments.Commands.DeleteComment;
using TouristAppBackend.Application.Comments.Commands.UpdateComment;

namespace TouristAppBackend.Controllers
{
    [Route("api/comment")]
    [ApiController]
    [EnableCors("My CORS policy")]
    public class CommentController : BaseController
    {
        /// <summary>
        /// Creates new comnent
        /// </summary>
        /// <param name="command">CreateCommentCommand object, coordinates must be provided from frontend</param>
        /// <returns>Created comment body</returns>
        /// 
        [HttpPost("place")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Creates new comnent
        /// </summary>
        /// <param name="command">CreatePictureCommentCommand object</param>
        /// <returns>Created comment body</returns>
        /// 
        [HttpPost("picture")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreatePictureCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Creates new comnent
        /// </summary>
        /// <param name="command">CreateTrackCommentCommand object</param>
        /// <returns>Created comment body</returns>
        /// 
        [HttpPost("track")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateTrackCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpPost]
        [Route("reply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Reply(CreateReplyCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(UpdateCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(DeleteCommentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
