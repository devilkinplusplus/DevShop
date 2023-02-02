using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.GetMyProducts
{
    public class GetMyProductsQueryHandler : IRequestHandler<GetMyProductsQueryRequest, GetMyProductsQueryResponse>
    {
        private readonly IProductReadRepository _productRead;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetMyProductsQueryHandler(IProductReadRepository productRead, IHttpContextAccessor httpContextAccessor)
        {
            _productRead = productRead;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetMyProductsQueryResponse> Handle(GetMyProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId is null)
            {
                errorList.Add(new() { Code = "404", Description = "User is not found" });
                return new() { Succeeded = false, Errors = errorList };
            }
            IEnumerable<Product> products = await _productRead
                    .GetAllAsync(x => x.IsDeleted == false && x.UserId == userId, request.Page, request.Size, "SubCatagory");

            if (products.Count() == 0)
            {
                errorList.Add(new() { Code = "404", Description = "You don't have any products :/" });
                return new() { Succeeded = false, Errors = errorList };
            }
            return new() { Succeeded = true, Products = products };
        }
    }
}
