using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductReadRepository _productRead;

        public GetAllProductsQueryHandler(IProductReadRepository productRead)
        {
            _productRead = productRead;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Product> products = await _productRead
                    .GetAllAsync(x => x.IsDeleted == false , request.Page, request.Size, "SubCatagory","User",
                                                            "ProductPictures.Picture");

            if (products.Count() == 0)
            {
                errorList.Add(new() { Code = "404", Description = " No products found :/" });
                return new() { Succeeded = false, Errors = errorList };
            }
            return new() { Succeeded = true, Products = products };
        }
    }
}
