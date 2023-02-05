﻿using DevShop.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Sales.GetMyPurschaes
{
    public class GetMyBuysQueryResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
        public List<IdentityError> Errors { get; set; }
    }
}
