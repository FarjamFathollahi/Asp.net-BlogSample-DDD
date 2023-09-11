using BlogApp.Contracts.Posts.Commands;
using BlogApp.Contracts.Posts.Commands.CreatePost;
using BlogApp.Contracts.Posts.Commands.DeletePost;
using BlogApp.Contracts.Posts.Commands.EditPost;
using BlogApp.Contracts.Posts.Commands.GetAllPost;
using BlogApp.Contracts.Posts.Commands.GetPost;
using BlogApp.Contracts.Posts.Repositories;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<CreatePostResult> CreatePostAsync(CreatePostCommand request, CancellationToken cancellationToken = default)
        {
            var post = new Post(request.Title, request.Content);
            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new CreatePostResult(post.Id);
        }

        public async Task<GetPostResult> GetPostAsync(GetPostQuery request, CancellationToken cancellationToken = default)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);
            return new GetPostResult
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreateDateTime = post.CreatedAt
            };
        }
        public async Task<EditPostResult> EditPostAsync(EditPostCommand request, CancellationToken cancellationToken = default)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);
            post.EditPost(request.Title, request.Content);
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new EditPostResult();
        }

        public async Task<List<GetAllPostsResult>> GetAllPostsAsync(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync(cancellationToken);
            var result = posts.Select(p => new GetAllPostsResult
            {
                Id = p.Id,
                Title = p.Title,
                CommentsCount = p.Comments.Count
            }).ToList();
            return result;
        }

        public async Task<DeletePostResult> DeletePostAsync(DeletePostCommand request, CancellationToken cancellationToken = default)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);
            _postRepository.Remove(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new DeletePostResult();
        }
    }
}
