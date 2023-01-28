using DevShop.Application.Repositories.Catagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Catagories.CatagoryList
{
    public class CatagoryListHandler : IRequestHandler<CatagoryListQuery, CatagoryListQueryResponse>
    {
        private readonly ICatagoryReadRepository _catagoryRead;

        public CatagoryListHandler(ICatagoryReadRepository catagoryRead)
        {
            _catagoryRead = catagoryRead;
        }

        public async Task<CatagoryListQueryResponse> Handle(CatagoryListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Catagory> catagories = await _catagoryRead.GetAllAsync(x => x.IsDeleted == false);
            if (catagories.Count() == 0)
                return new() { Succeeded = false };
            return new() { Succeeded = true, Catagories = catagories };
        }
    }
}
