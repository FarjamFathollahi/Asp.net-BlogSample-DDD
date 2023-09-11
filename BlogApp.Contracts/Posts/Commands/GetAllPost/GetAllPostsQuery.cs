using MediatR;

namespace BlogApp.Contracts.Posts.Commands.GetAllPost
{
    public class GetAllPostsQuery : IRequest<List<GetAllPostsResult>>
    {
    }
}
