using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;

namespace DevShop.Application.Cqrs.Queries.Sales.LastActions
{
    public class LastActionsQueryHandler : IRequestHandler<LastActionsQueryRequest, LastActionsQueryResponse>
    {
        private readonly ISaleService _saleService;
        public LastActionsQueryHandler(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<LastActionsQueryResponse> Handle(LastActionsQueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Sale> result = await _saleService.GetLastActivities(request.UserId);
            if(result.Count() == 0)
                return new(){Succeeded = false};
            return new(){Succeeded = true,Sales = result};
        }
    }
}