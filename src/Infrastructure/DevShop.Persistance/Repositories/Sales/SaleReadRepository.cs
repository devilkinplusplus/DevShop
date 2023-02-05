﻿using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Sales;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Sales
{
    public class SaleReadRepository : ReadRepository<Sale>, ISaleReadRepository
    {
        public SaleReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
