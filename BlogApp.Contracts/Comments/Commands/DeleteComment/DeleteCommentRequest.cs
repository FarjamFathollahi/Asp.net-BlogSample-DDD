namespace BlogApp.Contracts.Comments.Commands.DeleteComment
{
    public class DeleteCommentRequest
    {
        public DeleteCommentRequest(string id, string postId)
        {
            Id = id;
            PostId = postId;
        }

        public string Id { get; set; }
        public string PostId { get; set; }
    }
}
