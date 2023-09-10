namespace BlogApp.Domain.Entities
{
    public class Post : AggregateRoot<string>
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<Comment> _comments = new List<Comment>();
        public IReadOnlyList<Comment> Comments => _comments;

        private Post()
        {
            // Required by Entity Framework or other ORMs
        }

        public Post(string title, string content)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public void EditPost(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public Comment GetComment(string commentId)
        {
            return _comments.SingleOrDefault(c => c.Id == commentId);
        }

        public Comment AddComment(string content, string author)
        {
            var comment = new Comment(content, author);
            _comments.Add(comment);
            return comment;
        }
        public void DeleteComment(Comment comment)
        {
            _comments.Remove(comment);
        }
    }
}
