using BlogApp.Contracts.Posts.Commands.EditPost;
using BlogApp.Contracts.Posts.Repositories;
using MediatR;

namespace BlogApp.Application.Posts.EditPost
{
    public class EditPostHandler : IRequestHandler<EditPostCommand, EditPostResult>
    {
        IPostRepository _postRepository;
        public EditPostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<EditPostResult> Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);
            post.EditPost(request.Title, request.Content);
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new EditPostResult();
        }
    }
}
