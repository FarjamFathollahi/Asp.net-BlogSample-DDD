using MediatR;

namespace BlogApp.Contracts.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<CreatePostResult>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
