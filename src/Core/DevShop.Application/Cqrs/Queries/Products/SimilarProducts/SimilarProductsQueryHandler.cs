using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.SimilarProducts
{
    public class SimilarProductsQueryHandler : IRequestHandler<SimilarProductsQueryRequest, SimilarProductsQueryResponse>
    {
        private readonly IProductService _productService;

        public SimilarProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<SimilarProductsQueryResponse> Handle(SimilarProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Product> products = await _productService
                            .SimilarProducts(request.SubCatagoryId, request.ProductId);
            if (products.Count() == 0)
            {
                errorList.Add(new() { Description = "No similar products found" });
                return new() { Succeeded = false, Errors = errorList };
            }

            return new() { Succeeded = true, Products = products };

        }

    }
}
