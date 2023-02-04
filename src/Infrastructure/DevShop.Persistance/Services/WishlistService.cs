using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DevShop.Persistance.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly AppDbContext _context;

        public WishlistService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wishlist>> GetWishlists(string userId, int page = 1, int size = 10)
        {
            return await _context.Wishlist.Include(x => x.Product).Include(x=>x.Product)
                        .ThenInclude(x=>x.ProductPictures).ThenInclude(x=>x.Picture)
                        .Where(x => x.IsDeleted == false && x.UserId == userId).ToPagedListAsync(page,size);
        }
    }
}
