using DevShop.Application.DTOs.User;
using DevShop.Application.Repositories.Catagorysub;
using DevShop.Application.Repositories.Subcatagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Subcatagories.Delete
{
    public class DeleteSubcatagoryHandler : IRequestHandler<DeleteSubcatagoryCommand, DeleteSubcatagoryCommandResponse>
    {
        private readonly ISubcatagoryWriteRepository _subcatagoryWrite;
        private readonly ISubcatagoryReadRepository _subcatagoryRead;
        private readonly ICatagorysubReadRepository _catagorysubRead;
        private readonly ICatagorysubWriteRepository _catagorysubWrite;
        public DeleteSubcatagoryHandler(ISubcatagoryWriteRepository subcatagoryWrite, ISubcatagoryReadRepository subcatagoryRead, ICatagorysubReadRepository catagorysubRead, ICatagorysubWriteRepository catagorysubWrite)
        {
            _subcatagoryWrite = subcatagoryWrite;
            _subcatagoryRead = subcatagoryRead;
            _catagorysubRead = catagorysubRead;
            _catagorysubWrite = catagorysubWrite;
        }

        public async Task<DeleteSubcatagoryCommandResponse> Handle(DeleteSubcatagoryCommand request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();

            if (request.Id == null)
            {
                errorList.Add(new IdentityError() { Code = "404",Description = "Id is null"});
                return new() { Succeeded = false ,Errors = errorList};
            }
            
            SubCatagory currentData = await _subcatagoryRead.GetByIdAsync(request.Id);
            currentData.IsDeleted = true;
            await _subcatagoryWrite.UpdateAsync(currentData);


            CatagorySub data = await _catagorysubRead.GetAsync(x=>x.SubCatagoryId == currentData.Id);
            
            if(data is null)
            {
                errorList.Add(new() { Code = "404", Description = "An error occured while deleting" });
                return new() { Succeeded = false ,Errors = errorList};
            }

            data.IsDeleted = true;
            await _catagorysubWrite.UpdateAsync(data);

            return new() { Succeeded = true };
        }
    }
}
