using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.PopularProducts
{
    public class PopularProductsQueryHandler : IRequestHandler<PopularProductsQueryRequest, PopularProductsQueryResponse>
    {
        private readonly IProductService _productService;

        public PopularProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<PopularProductsQueryResponse> Handle(PopularProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();

            IEnumerable<Product> products = await _productService.GetPopularProducts();
            if(products.Count() == 0)
            {
                errorList.Add(new() { Code = "404", Description = "No products found :/" });
                return new() { Succeeded = false, Errors = errorList };
            }
            return new() { Products = products, Succeeded = true };
        }
    }
}
