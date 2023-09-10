using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Posts.Commands.CreatePost
{
    public class CreatePostResult
    {
        public string Id { get; set; }

        public CreatePostResult(string id)
        {
            Id = id;
        }
    }
}
