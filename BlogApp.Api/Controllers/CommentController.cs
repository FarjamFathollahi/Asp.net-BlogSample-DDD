using BlogApp.Contracts.Comments.Commands.CreateComment;
using BlogApp.Contracts.Comments.Commands.DeleteComment;
using BlogApp.Contracts.Comments.Commands.GetAllComment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateCommentCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("{postId}")]
        public async Task<IActionResult> Get(string postId)
        {
            return Ok(await _mediator.Send(new GetAllCommentQuery(postId)));
        }
        [HttpDelete("{postId}/{commentId}")]
        public async Task<IActionResult> Delete(string postId, string commentId)
        {
            return Ok(await _mediator.Send(new DeleteCommentCommand(commentId, postId)));
        }
    }
}
