using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Replies.Create
{
    public class CreateReplyCommandRequest:IRequest<CreateReplyCommandResponse>
    {
        public Reply Reply { get; set; }
        public Guid ContactId { get; set; }
    }
}
