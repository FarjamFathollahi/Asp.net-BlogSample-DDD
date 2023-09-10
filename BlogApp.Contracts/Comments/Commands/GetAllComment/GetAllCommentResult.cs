namespace BlogApp.Contracts.Comments.Commands.GetAllComment
{
    public class GetAllCommentResult
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Author { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}
