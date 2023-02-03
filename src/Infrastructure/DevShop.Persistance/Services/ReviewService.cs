using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;
        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviews(Guid productId)
        {
            var result = await _context.Reviews.Include(x => x.User).Include(x => x.Product)
                    .Where(x => x.IsDeleted == false && x.ProductId == productId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Review>> GetMyReviews(Guid productId, string userId)
        {
            var result = await _context.Reviews.Include(x => x.User).Include(x => x.Product)
                    .Where(x => x.IsDeleted == false && x.ProductId == productId && x.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<int> ReviewCountsOfProduct(Guid productId)
        {
            int count = await _context.Reviews.Where(x => x.IsDeleted == false && x.ProductId == productId).CountAsync();
            return count;
        }
    }
}
