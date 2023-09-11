using BlogApp.Contracts.Comments.Commands;
using BlogApp.Contracts.Comments.Commands.CreateComment;
using BlogApp.Contracts.Comments.Commands.DeleteComment;
using BlogApp.Contracts.Comments.Commands.GetAllComment;
using BlogApp.Contracts.Posts.Repositories;

namespace BlogApp.Application.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IPostRepository _postRepository;
        public CommentService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<CreateCommentResult> CreateComment(CreateCommentCommand request, CancellationToken cancellationToken = default)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);
            if (post == null)
                throw new NullReferenceException("Post Not Found.");
            var comment = post.AddComment(request.Content, request.Author);
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new CreateCommentResult(comment.Id);
        }

        public async Task<DeleteCommentResult> DeleteComment(DeleteCommentCommand request, CancellationToken cancellationToken = default)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);
            var comment = post.GetComment(request.Id);
            post.DeleteComment(comment);
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new DeleteCommentResult();
        }

        public async Task<List<GetAllCommentResult>> GetAllCommentsAsync(GetAllCommentQuery request, CancellationToken cancellationToken = default)
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
