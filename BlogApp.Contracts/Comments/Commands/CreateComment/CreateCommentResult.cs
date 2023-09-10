using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Comments.Commands.CreateComment
{
    public class CreateCommentResult
    {
        public string Id { get; set; }

        public CreateCommentResult(string id)
        {
            Id = id;
        }
    }
}
