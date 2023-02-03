using AutoMapper;
using DevShop.Application.Repositories.Products;
using DevShop.Application.Validations;
using DevShop.Domain.Entities.Concrete;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Products.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadRepository _productRead;
        private readonly IProductWriteRepository _productWrite;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductReadRepository productRead, IProductWriteRepository productWrite, IMapper mapper)
        {
            _productRead = productRead;
            _productWrite = productWrite;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            ProductValidator validations = new ProductValidator();
            Product newData = _mapper.Map<Product>(request.ProductDto);
            Product currentData = await _productRead.GetByIdAsync(request.Id);

            ValidationResult results = validations.Validate(newData);

            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    errorList.Add(new() { Code = error.ErrorCode, Description = error.ErrorMessage });
                }
                return new() { Succeeded = false, Errors = errorList ,Product = currentData};
            }

            currentData.Title = newData.Title;
            currentData.Description = newData.Description;
            currentData.Quantity = newData.Quantity;
            currentData.Price = newData.Price;
            currentData.Discount = newData.Discount;
            currentData.SubCatagoryId = newData.SubCatagoryId;

            await _productWrite.UpdateAsync(currentData);

            return new() { Succeeded = true, Product = currentData };

        }
    }
}
