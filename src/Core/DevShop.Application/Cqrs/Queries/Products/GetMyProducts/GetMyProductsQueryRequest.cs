using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.GetMyProducts
{
    public class GetMyProductsQueryRequest:IRequest<GetMyProductsQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
