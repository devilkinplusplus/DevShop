using DevShop.Application.Repositories.Catagory;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Catagory
{
    public class CatagoryWriteRepository : WriteRepository<Domain.Entities.Concrete.Catagory>, ICatagoryWriteRepository
    {
        public CatagoryWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
