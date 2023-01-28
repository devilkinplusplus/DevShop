using DevShop.Application.Repositories.Catagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Catagories.GetCatagoryById
{
    public class GetCatagoryByIdHandler : IRequestHandler<GetCatagoryByIdQuery, GetCatagoryByIdQueryResponse>
    {
        private readonly ICatagoryReadRepository _catagoryRead;

        public GetCatagoryByIdHandler(ICatagoryReadRepository catagoryRead)
        {
            _catagoryRead = catagoryRead;
        }

        public async Task<GetCatagoryByIdQueryResponse> Handle(GetCatagoryByIdQuery request, CancellationToken cancellationToken)
        {
            Catagory catagory = await _catagoryRead.GetByIdAsync(request.Id);
            if (catagory is null)
                return new() { Succeeded = false };
            return new() { Succeeded = true, Catagory = catagory };
        }
    }
}
