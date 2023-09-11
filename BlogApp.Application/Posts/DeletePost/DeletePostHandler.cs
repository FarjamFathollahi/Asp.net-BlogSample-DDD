using BlogApp.Contracts.Posts.Commands.DeletePost;
using BlogApp.Contracts.Posts.Repositories;
using MediatR;

namespace BlogApp.Application.Posts.DeletePost
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, DeletePostResult>
    {
        IPostRepository _postRepository;

        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<DeletePostResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);
            _postRepository.Remove(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new DeletePostResult();
        }
    }
}
