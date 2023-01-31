using AutoMapper;
using DevShop.Application.DTOs.User;
using DevShop.Application.Repositories.Catagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Catagories.UpdateCatagory
{
    public class UpdateCatagoryHandler : IRequestHandler<UpdateCatagoryCommand, UpdateCatagoryCommandResponse>
    {
        private readonly ICatagoryWriteRepository _catagoryWrite;
        private readonly ICatagoryReadRepository _catagoryRead;
        private readonly IMapper _mapper;
        public UpdateCatagoryHandler(ICatagoryWriteRepository catagoryWrite, IMapper mapper, ICatagoryReadRepository catagoryRead)
        {
            _catagoryWrite = catagoryWrite;
            _mapper = mapper;
            _catagoryRead = catagoryRead;
        }

        public async Task<UpdateCatagoryCommandResponse> Handle(UpdateCatagoryCommand request, CancellationToken cancellationToken)
        
        {
            List<IdentityError> errorList = new();
            if (request.Catagory.Name is null || request.Id == null)
            {
                errorList.Add(new() { Code = "404", Description = "Catagory name cannot be null" });
                return new() { Succeeded = false ,Errors = errorList};
            }

            Catagory data = _mapper.Map<Catagory>(request.Catagory);
            Catagory currentData = await _catagoryRead.GetByIdAsync(request.Id);
            currentData.Name = data.Name;

            await _catagoryWrite.UpdateAsync(currentData);
            return new() { Succeeded = true };
        }
    }

}
