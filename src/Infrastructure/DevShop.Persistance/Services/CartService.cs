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
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetCarts(string userId,int page = 1, int size = 10)
        {
            IEnumerable<Cart> result = await _context.Cart.Include(x=>x.Product)
                .Include(x=>x.Product).ThenInclude(x=>x.ProductPictures).ThenInclude(x=>x.Picture)
                .Where(x=> x.UserId == userId && x.IsDeleted == false).ToPagedListAsync(page,size);
            return result;
        }
    }
}
