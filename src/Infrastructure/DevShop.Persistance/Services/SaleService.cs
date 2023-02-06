using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Sales;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DevShop.Persistance.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleWriteRepository _saleWrite;
        private readonly AppDbContext _context;
        public SaleService(ISaleWriteRepository saleWrite, AppDbContext context)
        {
            _saleWrite = saleWrite;
            _context = context;
        }

        public async Task CreateSales(Guid productId, string buyerId, string sellerId)
        {
            await _saleWrite.AddAsync(new()
            {
                ProductId = productId,
                BuyerId = buyerId,
                SellerId = sellerId,
                SaleDate = DateTime.Now
            });
        }

        public async Task<IEnumerable<Sale>> GetBuys(string userId,int page = 1,int size = 10)
        {
            return await _context.Sales.Include(x => x.Product).Include(x => x.Seller).Include(x => x.Buyer)
                                .Where(x => x.BuyerId == userId && x.IsDeleted == false).ToPagedListAsync(page, size);
        }

        public async Task<IEnumerable<Sale>> GetLastActivities(string userId)
        {
            return await _context.Sales.Include(x=>x.Product).Include(x=>x.Buyer).Include(x=>x.Seller).OrderByDescending(x=>x.SaleDate)
                            .Where(x=>x.BuyerId == userId || x.SellerId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSales(string userId,int page = 1, int size = 10)
        {
            return await _context.Sales.Include(x=>x.Product).Include(x=>x.Seller).Include(x=>x.Buyer)
                                 .Where(x => x.SellerId == userId && x.IsDeleted == false).ToPagedListAsync(page,size);
        }
    }
}
