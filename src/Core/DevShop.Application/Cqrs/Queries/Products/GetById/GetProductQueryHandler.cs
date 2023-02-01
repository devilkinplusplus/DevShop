using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Products.GetById
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, GetProductQueryResponse>
    {
        private readonly IProductReadRepository _productRead;

        public GetProductQueryHandler(IProductReadRepository productRead)
        {
            _productRead = productRead;
        }

        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            if (request.Id == null)
            {
                errorList.Add(new() { Code = "404", Description = "Id is not found" });
                return new()
                {
                    Errors = errorList,
                    Succeeded = false
                };
            }

            Product product = await _productRead.GetAsync(x => x.IsDeleted == false && x.Id == request.Id,
                                                    "SubCatagory");
            if(product is null)
            {
                errorList.Add(new() { Code = "404", Description = "Product is not found" });
                return new() { Errors = errorList, Succeeded = false };
            }

            return new() { Product = product, Succeeded = true };
        }
    }
}
