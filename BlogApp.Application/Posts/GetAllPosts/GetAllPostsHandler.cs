using BlogApp.Contracts.Posts.Commands.GetAllPost;
using BlogApp.Contracts.Posts.Repositories;
using MediatR;

namespace BlogApp.Application.Posts.GetAllPosts
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPostQuery, List<GetAllPostResult>>
    {
        IPostRepository _postRepository;
        public GetAllPostsHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<GetAllPostResult>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync(cancellationToken);
            var result = posts.Select(p => new GetAllPostResult
            {
                Id = p.Id,
                Title = p.Title,
                CommentsCount = p.Comments.Count
            }).ToList();
            return result;
        }
    }
}
