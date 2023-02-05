using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace DevShop.Application.Cqrs.Queries.Sales.GetMySales
{
    public class GetMySalesQueryResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
        public List<IdentityError> Errors { get; set; }
    }
}