using MediatR;

namespace BlogApp.Contracts.Posts.Commands.GetAllPost
{
    public class GetAllPostQuery : IRequest<List<GetAllPostResult>>
    {
    }
}
