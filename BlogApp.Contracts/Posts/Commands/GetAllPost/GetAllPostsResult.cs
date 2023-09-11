using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Posts.Commands.GetAllPost
{
    public class GetAllPostsResult
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int CommentsCount { get; set; }
    }
}
