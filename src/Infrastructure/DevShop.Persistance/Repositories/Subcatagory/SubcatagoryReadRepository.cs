using DevShop.Application.Repositories.Subcatagory;
using DevShop.Application.Validations;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Subcatagory
{
    public class SubcatagoryReadRepository : ReadRepository<SubCatagory>, ISubcatagoryReadRepository
    {
        public SubcatagoryReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

       
    }
}
