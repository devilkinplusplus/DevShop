using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Replies.GetById
{
    public class GetReplyQueryRequest:IRequest<GetReplyQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
