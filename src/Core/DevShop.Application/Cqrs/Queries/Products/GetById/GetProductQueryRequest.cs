using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.GetById
{
    public class GetProductQueryRequest:IRequest<GetProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
