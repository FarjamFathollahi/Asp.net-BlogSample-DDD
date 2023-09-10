using BlogApp.Contracts.Comments.Commands;
using BlogApp.Contracts.Comments.Commands.CreateComment;
using BlogApp.Contracts.Comments.Commands.DeleteComment;
using BlogApp.Contracts.Comments.Commands.GetAllComment;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateCommentRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _commentService.CreateComment(request, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{postId}")]
        public async Task<IActionResult> Get(string postId, CancellationToken cancellationToken = default)
        {
            return Ok(await _commentService.GetAllCommentsAsync(new GetAllCommentRequest(postId), cancellationToken));
        }
        [HttpDelete("{postId}/{commentId}")]
        public async Task<IActionResult> Delete(string postId, string commentId, CancellationToken cancellationToken = default)
        {
            return Ok(await _commentService.DeletComment(new DeleteCommentRequest(commentId , postId) ,cancellationToken));
        }


    }
}
