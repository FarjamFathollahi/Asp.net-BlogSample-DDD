using BlogApp.Contracts.Posts.Repositories;
using BlogApp.Domain.Entities;
using MediatR;

namespace BlogApp.Contracts.Posts.Commands.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostRequest, CreatePostResult>
    {
        IPostRepository _repository;
        public CreatePostHandler(IPostRepository repository)
        {
            _repository = repository;
        }
        public async Task<CreatePostResult> Handle(CreatePostRequest request, CancellationToken cancellationToken = default)
        {
            var newPost = new Post(request.Title, request.Content);
            await _repository.AddAsync(newPost, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return new CreatePostResult(newPost.Id);
        }
    }
}
