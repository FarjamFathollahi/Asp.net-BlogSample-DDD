namespace BlogApp.Domain.Entities
{
    public class Comment : Entity<string>
    {
        public string Content { get; private set; }
        public string Author { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Post Post { get; set; }
        public string PostId { get; set; }

        private Comment()
        {
            // Required by Entity Framework or other ORMs
        }

        public Comment(string content, string author)
        {
            Id = Guid.NewGuid().ToString();
            Content = content;
            Author = author;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
