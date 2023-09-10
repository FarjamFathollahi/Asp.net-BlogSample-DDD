﻿using Microsoft.AspNetCore.Mvc;
using BlogApp.Contracts.Posts.Commands.GetPost;
using BlogApp.Contracts.Posts.Commands.CreatePost;
using BlogApp.Contracts.Posts.Commands;
using BlogApp.Contracts.Posts.Commands.EditPost;
using BlogApp.Contracts.Posts.Commands.GetAllPost;
using BlogApp.Contracts.Posts.Commands.DeletePost;

namespace BlogApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            return Ok(await _postService.GetAllPostsAsync(new GetAllPostRequest(), cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await _postService.GetPostAsync(new GetPostRequest(id), cancellationToken));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreatePostRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await _postService.CreatePostAsync(request, cancellationToken));
        }
        [HttpPut]
        public async Task<IActionResult> Put(EditPostRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await _postService.EditPostAsync(request, cancellationToken));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await _postService.DeletePostAsync(new DeletePostRequest(id), cancellationToken));
        }
    }
}