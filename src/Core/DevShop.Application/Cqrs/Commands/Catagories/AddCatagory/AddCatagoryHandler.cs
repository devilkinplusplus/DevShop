using AutoMapper;
using DevShop.Application.Repositories.Catagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Catagories.AddCatagory
{
    public class AddCatagoryHandler : IRequestHandler<AddCatagoryCommand, AddCatagoryCommandResponse>
    {
        private readonly ICatagoryWriteRepository _catagoryWrite;
        private readonly IMapper _mapper;

        public AddCatagoryHandler(IMapper mapper, ICatagoryWriteRepository catagoryWrite)
        {
            _mapper = mapper;
            _catagoryWrite = catagoryWrite;
        }

        public async Task<AddCatagoryCommandResponse> Handle(AddCatagoryCommand request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            Catagory data = _mapper.Map<Catagory>(request.Catagory);
            if (request.Catagory.Name is null)
            {
                errorList.Add(new() { Code = "404", Description = "Catagory name cannot be null" });
                return new() { Succeeded =false,Errors = errorList};
            }
            await _catagoryWrite.AddAsync(data);
            return new() { Succeeded = true };
        }
    }
}
