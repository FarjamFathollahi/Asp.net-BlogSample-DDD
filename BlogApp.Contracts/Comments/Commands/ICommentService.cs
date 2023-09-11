using BlogApp.Contracts.Comments.Commands.CreateComment;
using BlogApp.Contracts.Comments.Commands.DeleteComment;
using BlogApp.Contracts.Comments.Commands.GetAllComment;

namespace BlogApp.Contracts.Comments.Commands
{
    public interface ICommentService
    {
        Task<List<GetAllCommentResult>> GetAllCommentsAsync(GetAllCommentQuery request, CancellationToken cancellationToken = default);
        Task<CreateCommentResult> CreateComment(CreateCommentCommand request, CancellationToken cancellationToken = default);
        Task<DeleteCommentResult> DeleteComment(DeleteCommentCommand request, CancellationToken cancellationToken = default);
    }
}
