using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.PopularProducts
{
    public class PopularProductsQueryRequest:IRequest<PopularProductsQueryResponse>
    {
    }
}
