using MediatR;

namespace BlogApp.Contracts.Posts.Commands.EditPost
{
    public class EditPostCommand : IRequest<EditPostResult>
    {
        public EditPostCommand(string id, string title, string content)
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
