using DevShop.Application.Repositories.ProductPictures;
using DevShop.Application.Repositories.Products;
using DevShop.Application.Validations;
using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DevShop.Application.Cqrs.Commands.Products.Create
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommandRequest, ProductCreateCommandResponse>
    {
        private readonly IProductWriteRepository _productWrite;
        private readonly IProductPictureWriteRepository _productPictureWrite;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductCreateCommandHandler(IProductWriteRepository productWrite, IProductPictureWriteRepository productPictureWrite, IHttpContextAccessor httpContextAccessor)
        {
            _productWrite = productWrite;
            _productPictureWrite = productPictureWrite;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ProductCreateCommandResponse> Handle(ProductCreateCommandRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            request.Product.UserId = userId;
            request.Product.CreatedDate = DateTime.Now;

            ProductValidator validations = new ProductValidator();
            ValidationResult results = validations.Validate(request.Product);
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    errorList.Add(new() { Code = error.ErrorCode, Description = error.ErrorMessage });
                }
                return new() { Succeeded = false, Errors = errorList };
            }

            await _productWrite.AddAsync(request.Product);

            for (int i = 0; i < request.PictureIds.Count; i++)
            {
                if (request.PictureIds[i] is null)
                {
                    errorList.Add(new() { Code = "404", 
                        Description = "You should select picture for your product!" });
                    return new() { Succeeded = false, Errors = errorList };
                }
            }

            for (int i = 0; i < request.PictureIds.Count; i++)
            {
                await _productPictureWrite.AddAsync(new()
                {
                    ProductId = request.Product.Id,
                    PictureId = Guid.Parse(request.PictureIds[i])
                });
            }

            return new() { Succeeded = true };
        }
    }
}
