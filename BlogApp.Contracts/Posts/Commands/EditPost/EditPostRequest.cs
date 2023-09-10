namespace BlogApp.Contracts.Posts.Commands.EditPost
{
    public class EditPostRequest
    {
        public EditPostRequest(string id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
