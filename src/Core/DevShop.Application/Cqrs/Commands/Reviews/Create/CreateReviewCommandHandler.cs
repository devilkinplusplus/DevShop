using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Reviews;
using DevShop.Application.Validations;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Reviews.Create
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        private readonly IReviewWriteRepository _reviewWrite;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductService _productService;
        public CreateReviewCommandHandler(IReviewWriteRepository reviewWrite, IHttpContextAccessor httpContextAccessor, IProductService productService)
        {
            _reviewWrite = reviewWrite;
            _httpContextAccessor = httpContextAccessor;
            _productService = productService;
        }

        public async Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            ReviewValidator validations = new ReviewValidator();
            request.UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.Review.UserId = request.UserId;
            ValidationResult result = validations.Validate(request.Review);


            if (result.IsValid)
            {
                await _reviewWrite.AddAsync(request.Review);
                await _productService.CalculateRating(request.Review.ProductId);
                return new() { Succeeded = true };
            }
            foreach (var item in result.Errors)
            {
                errorList.Add(new() { Description = item.ErrorMessage });
            }
            return new() { Errors = errorList, Succeeded = false };

        }
    }
}
