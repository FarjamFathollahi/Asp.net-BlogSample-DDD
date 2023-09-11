using MediatR;

namespace BlogApp.Contracts.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CreateCommentResult>
    {
        public string PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
