using BlogApp.Contracts.Posts.Commands.CreatePost;
using BlogApp.Contracts.Posts.Commands.DeletePost;
using BlogApp.Contracts.Posts.Commands.EditPost;
using BlogApp.Contracts.Posts.Commands.GetAllPost;
using BlogApp.Contracts.Posts.Commands.GetPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _mediator.Send(new GetAllPostQuery());
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var post = await _mediator.Send(new GetPostQuery(id));
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreatePostCommand request)
        {
            var post = await _mediator.Send(request);
            return Ok(post);
        }
        [HttpPut]
        public async Task<IActionResult> Put(EditPostCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _mediator.Send(new DeletePostCommand(id)));
        }
    }
}
