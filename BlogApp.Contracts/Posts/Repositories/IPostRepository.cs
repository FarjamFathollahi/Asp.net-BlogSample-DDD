using BlogApp.Domain.Entities;

namespace BlogApp.Contracts.Posts.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetByIdAsync(string postId, CancellationToken cancellationToken = default);
        Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Post post, CancellationToken cancellationToken = default);
        void Update(Post post);
        void Remove(Post post);
        void RemoveComment(Comment comment);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
