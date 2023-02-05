using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Sales.GetMyPurschaes
{
    public class GetMyBuysQueryHandler : IRequestHandler<GetMyBuysQueryRequest, GetMyBuysQueryResponse>
    {
        private readonly ISaleService _saleService;

        public GetMyBuysQueryHandler(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<GetMyBuysQueryResponse> Handle(GetMyBuysQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Sale> sales = await _saleService.GetBuys(request.UserId,request.Page,request.Size);

            if (sales.Count() == 0)
            {
                errorList.Add(new() { Description = "You have no sales yet :/" });
                return new() { Errors = errorList, Succeeded = false };
            }
            return new() { Succeeded = true, Sales = sales };
        }
    }
}
