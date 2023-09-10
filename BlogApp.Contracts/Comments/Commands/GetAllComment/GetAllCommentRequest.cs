namespace BlogApp.Contracts.Comments.Commands.GetAllComment
{
    public class GetAllCommentRequest
    {
        public string PostId { get; set; }

        public GetAllCommentRequest(string postId)
        {
            PostId = postId;
        }
    }
}
