using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.NewProducts
{
    public class NewProductsQueryHandler : IRequestHandler<NewProductsQueryRequest, NewProductsQueryResponse>
    {
        private readonly IProductService _productService;

        public NewProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<NewProductsQueryResponse> Handle(NewProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Product> products = await _productService.GetNewProducts();

            if (products.Count() == 0)
            {
                errorList.Add(new() { Description = "No products found" });
                return new() { Errors = errorList, Succeeded = false };
            }
            return new() { Succeeded = true,Products = products};
        }
    }
}
