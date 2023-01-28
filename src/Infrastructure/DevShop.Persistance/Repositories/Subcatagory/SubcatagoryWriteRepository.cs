using DevShop.Application.Repositories.Subcatagory;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Subcatagory
{
    public class SubcatagoryWriteRepository : WriteRepository<SubCatagory>, ISubcatagoryWriteRepository
    {
        public SubcatagoryWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
