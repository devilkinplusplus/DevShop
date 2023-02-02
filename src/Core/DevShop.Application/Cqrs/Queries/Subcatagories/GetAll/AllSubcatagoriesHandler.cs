using DevShop.Application.Repositories.Catagory;
using DevShop.Application.Repositories.Subcatagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Subcatagories.GetAll
{
    public class AllSubcatagoriesHandler : IRequestHandler<AllSubcatagoriesQuery, AllSubcatagoriesResponse>
    {
        private readonly ISubcatagoryReadRepository _subcatagoryRead;
        public AllSubcatagoriesHandler(ISubcatagoryReadRepository subcatagoryRead)
        {
            _subcatagoryRead = subcatagoryRead;
        }

        public async Task<AllSubcatagoriesResponse> Handle(AllSubcatagoriesQuery request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<SubCatagory> subCatagories = await _subcatagoryRead
                                              .GetAllAsync(x=>x.IsDeleted == false,request.Page,request.Size);

            if (subCatagories.Count() == 0)
            {
                errorList.Add(new IdentityError() { Code = "404", Description = "No subcatagory found" });
                return new() { Succeeded = false ,Errors = errorList};
            }
            return new() { Succeeded = true , SubCatagories = subCatagories };
        }
    }
}
