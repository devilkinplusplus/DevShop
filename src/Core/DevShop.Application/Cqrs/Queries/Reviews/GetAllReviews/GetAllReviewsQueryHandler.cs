using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Reviews.GetAllReviews
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQueryRequest, GetAllReviewsQueryResponse>
    {
        private readonly IReviewService _reviewService;
        public GetAllReviewsQueryHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<GetAllReviewsQueryResponse> Handle(GetAllReviewsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Review> reviews = await _reviewService.GetAllReviews(request.ProductId);
            if (reviews.Count() == 0)
            {
                errorList.Add(new() { Description = "No review about this product,be first" });
                return new() { Errors = errorList, Succeeded = false };
            }
            return new() { Reviews = reviews, Succeeded = true };
        }
    }
}
