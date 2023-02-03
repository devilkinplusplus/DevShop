using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.SimilarProducts
{
    public class SimilarProductsQueryRequest:IRequest<SimilarProductsQueryResponse>
    {
        public Guid ProductId { get; set; }
        public Guid SubCatagoryId { get; set; }
    }
}
