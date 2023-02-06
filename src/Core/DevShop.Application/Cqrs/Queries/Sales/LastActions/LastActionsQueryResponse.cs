using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Concrete;

namespace DevShop.Application.Cqrs.Queries.Sales.LastActions
{
    public class LastActionsQueryResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
    }
}