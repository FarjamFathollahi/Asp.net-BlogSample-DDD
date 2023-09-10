namespace BlogApp.Contracts.Posts.Commands.GetPost
{
    public class GetPostRequest
    {
        public string Id { get; set; }

        public GetPostRequest(string id)
        {
            Id = id;
        }
    }
}
