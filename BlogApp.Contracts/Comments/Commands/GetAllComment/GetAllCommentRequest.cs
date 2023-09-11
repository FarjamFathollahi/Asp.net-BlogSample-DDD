using MediatR;

namespace BlogApp.Contracts.Comments.Commands.GetAllComment
{
    public class GetAllCommentQuery : IRequest<List<GetAllCommentResult>>
    {
        public string PostId { get; set; }

        public GetAllCommentQuery(string postId)
        {
            PostId = postId;
        }
    }
}
