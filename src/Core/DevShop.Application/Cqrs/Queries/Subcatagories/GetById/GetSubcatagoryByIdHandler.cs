using AutoMapper;
using DevShop.Application.Repositories.Subcatagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Subcatagories.GetById
{
    public class GetSubcatagoryByIdHandler : IRequestHandler<GetSubcatagoryByIdQuery, GetSubcatagoryByIdQueryResponse>
    {
        private readonly ISubcatagoryReadRepository _subcatagoryRead;
        private readonly ISubcatagoryWriteRepository _subcatagoryWrite;
        public GetSubcatagoryByIdHandler(ISubcatagoryReadRepository subcatagoryRead, ISubcatagoryWriteRepository subcatagoryWrite)
        {
            _subcatagoryRead = subcatagoryRead;
            _subcatagoryWrite = subcatagoryWrite;
        }

        public async Task<GetSubcatagoryByIdQueryResponse> Handle(GetSubcatagoryByIdQuery request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            if (request.Id == null)
            {
                errorList.Add(new() { Code = "404", Description = "Id is null" });
                return new() { Succeeded = false ,Errors = errorList};
            }
            SubCatagory data = await _subcatagoryRead.GetByIdAsync(request.Id);
            if(data is null)
            {
                errorList.Add(new() { Code = "404", Description = "No subcatagory found" });
                return new() { Succeeded = false, Errors = errorList };
            }

            return new() { Succeeded = true, SubCatagory = data };
        }
    }
}
