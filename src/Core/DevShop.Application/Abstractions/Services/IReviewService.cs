using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetMyReviews(Guid productId, string userId);
        Task<IEnumerable<Review>> GetAllReviews(Guid productId, int page = 1, int size = 10);
        Task<int> ReviewCountsOfProduct(Guid productId);
    }
}
