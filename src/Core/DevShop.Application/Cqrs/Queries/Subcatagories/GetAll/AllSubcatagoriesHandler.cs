using DevShop.Application.Repositories.Subcatagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<SubCatagory> results = await _subcatagoryRead.GetAllAsync();
            if (results.Count() == 0)
                return new() { Succeeded = false };
            return new() { Succeeded = true , SubCatagories = results};
        }
    }
}
