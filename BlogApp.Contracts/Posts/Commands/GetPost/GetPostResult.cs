namespace BlogApp.Contracts.Posts.Commands.GetPost
{
    public class GetPostResult
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
