using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Reviews.GetMyReviews
{
    internal class GetMyReviewsQueryHandler : IRequestHandler<GetMyReviewsQueryRequest, GetMyReviewsQueryResponse>
    {
        private readonly IReviewService _reviewService;

        public GetMyReviewsQueryHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<GetMyReviewsQueryResponse> Handle(GetMyReviewsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Review> reviews = await _reviewService.GetMyReviews(request.ProductId, request.UserId);
            if (reviews.Count() == 0)
            {
                errorList.Add(new() { Description = "Let us know what's your thoughts about this product" });
                return new() { Errors = errorList, Succeeded = false };
            }
            return new() { MyReviews = reviews, Succeeded = true };
        }
    }
}
