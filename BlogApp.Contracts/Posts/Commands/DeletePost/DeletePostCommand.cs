using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<DeletePostResult>
    {
        public string Id { get; set; }

        public DeletePostCommand(string id)
        {
            Id = id;
        }
    }
}
