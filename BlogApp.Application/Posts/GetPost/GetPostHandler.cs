using BlogApp.Contracts.Posts.Commands.GetPost;
using BlogApp.Contracts.Posts.Repositories;
using MediatR;

namespace BlogApp.Application.Posts.GetPost
{
    public class GetPostHandler : IRequestHandler<GetPostQuery, GetPostResult>
    {
        IPostRepository _postRepository;

        public GetPostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GetPostResult> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);
            return new GetPostResult
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreateDateTime = post.CreatedAt
            };
        }
    }
}
