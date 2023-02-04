using DevShop.Application.Repositories.Wishlists;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Wishlists
{
    public class WishlistWriteRepository : WriteRepository<Wishlist>, IWishlistWriteRepository
    {
        public WishlistWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
