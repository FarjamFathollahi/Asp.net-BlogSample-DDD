using MediatR;

namespace BlogApp.Contracts.Posts.Commands.GetPost
{
    public class GetPostQuery : IRequest<GetPostResult>
    {
        public string Id { get; set; }

        public GetPostQuery(string id)
        {
            Id = id;
        }
    }
}
