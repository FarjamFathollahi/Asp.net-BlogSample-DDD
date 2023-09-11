using MediatR;

namespace BlogApp.Contracts.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<DeleteCommentResult>
    {
        public DeleteCommentCommand(string id, string postId)
        {
            Id = id;
            PostId = postId;
        }

        public string Id { get; set; }
        public string PostId { get; set; }
    }
}
