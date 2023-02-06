using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace DevShop.Application.Cqrs.Queries.Sales.LastActions
{
    public class LastActionsQueryRequest:IRequest<LastActionsQueryResponse>
    {
        public string UserId { get; set; }
    }
}