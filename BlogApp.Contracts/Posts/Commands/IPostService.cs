using BlogApp.Contracts.Posts.Commands.CreatePost;
using BlogApp.Contracts.Posts.Commands.DeletePost;
using BlogApp.Contracts.Posts.Commands.EditPost;
using BlogApp.Contracts.Posts.Commands.GetAllPost;
using BlogApp.Contracts.Posts.Commands.GetPost;

namespace BlogApp.Contracts.Posts.Commands
{
    public interface IPostService
    {
        Task<List<GetAllPostResult>> GetAllPostsAsync(GetAllPostRequest request, CancellationToken cancellationToken = default);
        Task<GetPostResult> GetPostAsync(GetPostRequest request, CancellationToken cancellationToken = default);
        Task<CreatePostResult> CreatePostAsync(CreatePostRequest request, CancellationToken cancellationToken = default);
        Task<EditPostResult> EditPostAsync(EditPostRequest request, CancellationToken cancellationToken = default);
        Task<DeletePostResult> DeletePostAsync(DeletePostRequest request, CancellationToken cancellationToken = default);
    }
}
