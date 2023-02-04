using DevShop.Application.Repositories.Carts;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Carts
{
    public class CartWriteRepository : WriteRepository<Cart>, ICartWriteRepository
    {
        public CartWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
