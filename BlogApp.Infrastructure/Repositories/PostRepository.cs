using BlogApp.Contracts.Posts.Repositories;
using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Post post, CancellationToken cancellationToken = default)
        {
            await _context.Posts.AddAsync(post, cancellationToken);
        }
        public async Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Posts.Include(p => p.Comments).OrderByDescending(p => p.CreatedAt).ToListAsync(cancellationToken);
        }

        public async Task<Post> GetByIdAsync(string postId, CancellationToken cancellationToken = default)
        {
            return await _context.Posts.Include(p => p.Comments).SingleOrDefaultAsync(p => p.Id == postId, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
        }

        public void Remove(Post post)
        {
            _context.Posts.Remove(post);
        }

        public void RemoveComment(Comment comment)
        {
            _context.Comments.Remove(comment);
        }
    }
}
