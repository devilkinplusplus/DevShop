using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Replies.GetAll
{
    public class GetAllRepliesQueryRequest:IRequest<GetAllRepliesQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
