using DevShop.Application.Repositories.Catagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Catagories.DeleteCatagory
{
    public class DeleteCatagoryHandler : IRequestHandler<DeleteCatagoryCommand, DeleteCatagoryCommandResponse>
    {
        private readonly ICatagoryWriteRepository _catagoryWrite;
        private readonly ICatagoryReadRepository _catagoryRead;
        public DeleteCatagoryHandler(ICatagoryWriteRepository catagoryWrite, ICatagoryReadRepository catagoryRead)
        {
            _catagoryWrite = catagoryWrite;
            _catagoryRead = catagoryRead;
        }

        public async Task<DeleteCatagoryCommandResponse> Handle(DeleteCatagoryCommand request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            if (request.Id == null)
            {
                errorList.Add(new IdentityError() { Code = "404", Description = "Id is null" });
                return new() { Succeeded = false ,Errors = errorList};
            }

            Catagory catagory = await _catagoryRead.GetByIdAsync(request.Id);
            catagory.IsDeleted = true;
            
            await _catagoryWrite.UpdateAsync(catagory);
            return new() { Succeeded = true };
        }
    }
}
