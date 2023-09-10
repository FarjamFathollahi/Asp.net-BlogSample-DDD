using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Posts.Commands.DeletePost
{
    public class DeletePostRequest
    {
        public string Id { get; set; }

        public DeletePostRequest(string id)
        {
            Id = id;
        }
    }
}
