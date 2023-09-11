using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Posts.Commands.CreatePost
{
    public class CreatePostRequest : IRequest<CreatePostResult>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
