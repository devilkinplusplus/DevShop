using DevShop.Application.Repositories.Catagory;
using DevShop.Application.Repositories.Catagorysub;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Catagorysub
{
    public class CatagorysubReadRepository : ReadRepository<CatagorySub>, ICatagorysubReadRepository
    {
        public CatagorysubReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
