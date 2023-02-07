using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Replies.Delete
{
    public class DeleteReplyCommandRequest:IRequest<DeleteReplyCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
