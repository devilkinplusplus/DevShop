using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Reviews.GetMyReviews
{
    public class GetMyReviewsQueryRequest:IRequest<GetMyReviewsQueryResponse>
    {
        public Guid ProductId { get; set; }
        public string UserId { get; set; }
    }
}
