using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Comments.Commands.CreateComment
{
    public class CreateCommentRequest
    {
        public string PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
