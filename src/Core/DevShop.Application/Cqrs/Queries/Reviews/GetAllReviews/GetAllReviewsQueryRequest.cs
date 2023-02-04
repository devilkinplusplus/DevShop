using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Reviews.GetAllReviews
{
    public class GetAllReviewsQueryRequest:IRequest<GetAllReviewsQueryResponse>
    {
        public Guid ProductId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
