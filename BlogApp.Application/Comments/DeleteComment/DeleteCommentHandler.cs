using BlogApp.Contracts.Comments.Commands.DeleteComment;
using BlogApp.Contracts.Posts.Repositories;
using MediatR;

namespace BlogApp.Application.Comments.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentResult>
    {
        IPostRepository _postRepository;

        public DeleteCommentHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<DeleteCommentResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);
            var comment = post.GetComment(request.Id);
            post.DeleteComment(comment);
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new DeleteCommentResult();
        }
    }
}
