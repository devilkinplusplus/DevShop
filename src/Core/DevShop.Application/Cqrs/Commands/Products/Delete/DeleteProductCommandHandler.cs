using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Products.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductReadRepository _productRead;
        private readonly IProductWriteRepository _productWrite;
        public DeleteProductCommandHandler(IProductReadRepository productRead, IProductWriteRepository productWrite)
        {
            _productRead = productRead;
            _productWrite = productWrite;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            Product data = await _productRead.GetByIdAsync(request.Id);
            if(data is null)
            {
                errorList.Add(new() { Description = "Product not found" });
                return new() { Succeeded = false, Errors = errorList };
            }
            data.IsDeleted = true;
            await _productWrite.UpdateAsync(data);
            return new() { Succeeded = true };
        }
    }
}
