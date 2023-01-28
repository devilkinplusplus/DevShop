using DevShop.Application.Repositories.Catagory;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Catagory
{
    public class CatagoryReadRepository : ReadRepository<Domain.Entities.Concrete.Catagory>, ICatagoryReadRepository
    {
        public CatagoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
