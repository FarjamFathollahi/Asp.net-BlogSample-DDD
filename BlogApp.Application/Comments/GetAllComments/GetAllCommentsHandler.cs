using BlogApp.Contracts.Comments.Commands.GetAllComment;
using BlogApp.Contracts.Posts.Repositories;
using MediatR;

namespace BlogApp.Application.Comments.GetAllComments
{
    public class GetAllCommentsHandler : IRequestHandler<GetAllCommentQuery, List<GetAllCommentResult>>
    {
        IPostRepository _postRepository;

        public GetAllCommentsHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<GetAllCommentResult>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);
            var comments = post.Comments;

            return comments.Select(c => new GetAllCommentResult
            {
                Author = c.Author,
                Content = c.Content,
                CreatedAt = c.CreatedAt,
                Id = c.Id
            }).ToList();
        }
    }
}
