using BlogApp.Contracts.Comments.Commands.CreateComment;
using BlogApp.Contracts.Comments.Commands.DeleteComment;
using BlogApp.Contracts.Comments.Commands.GetAllComment;

namespace BlogApp.Contracts.Comments.Commands
{
    public interface ICommentService
    {
        Task<List<GetAllCommentResult>> GetAllCommentsAsync(GetAllCommentRequest request, CancellationToken cancellationToken = default);
        Task<CreateCommentResult> CreateComment(CreateCommentRequest request, CancellationToken cancellationToken = default);
        Task<DeleteCommentResult> DeleteComment(DeleteCommentRequest request, CancellationToken cancellationToken = default);
    }
}
