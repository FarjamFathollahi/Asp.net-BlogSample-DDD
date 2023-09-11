using BlogApp.Contracts.Posts.Commands.CreatePost;
using BlogApp.Contracts.Posts.Commands.DeletePost;
using BlogApp.Contracts.Posts.Commands.EditPost;
using BlogApp.Contracts.Posts.Commands.GetAllPost;
using BlogApp.Contracts.Posts.Commands.GetPost;

namespace BlogApp.Contracts.Posts.Commands
{
    public interface IPostService
    {
        Task<List<GetAllPostsResult>> GetAllPostsAsync(GetAllPostsQuery request, CancellationToken cancellationToken = default);
        Task<GetPostResult> GetPostAsync(GetPostQuery request, CancellationToken cancellationToken = default);
        Task<CreatePostResult> CreatePostAsync(CreatePostCommand request, CancellationToken cancellationToken = default);
        Task<EditPostResult> EditPostAsync(EditPostCommand request, CancellationToken cancellationToken = default);
        Task<DeletePostResult> DeletePostAsync(DeletePostCommand request, CancellationToken cancellationToken = default);
    }
}
