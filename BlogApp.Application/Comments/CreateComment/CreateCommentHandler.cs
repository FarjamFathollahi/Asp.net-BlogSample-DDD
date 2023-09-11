using BlogApp.Contracts.Comments.Commands.CreateComment;
using BlogApp.Contracts.Posts.Repositories;
using MediatR;

namespace BlogApp.Application.Comments.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CreateCommentResult>
    {
        IPostRepository _postRepository;

        public CreateCommentHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<CreateCommentResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);
            if (post == null)
                throw new NullReferenceException("Post Not Found.");
            var comment = post.AddComment(request.Content, request.Author);
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync(cancellationToken);
            return new CreateCommentResult(comment.Id);
        }
    }
}
