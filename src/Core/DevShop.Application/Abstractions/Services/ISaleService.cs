using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevShop.Application.Abstractions.Services
{
    public interface ISaleService
    {
        Task CreateSales(Guid productId, string buyerId,string sellerId);
        Task<IEnumerable<Sale>> GetSales(string userId, int page = 1, int size = 10);
        Task<IEnumerable<Sale>> GetBuys(string userId, int page = 1, int size = 10);
        Task<IEnumerable<Sale>> GetLastActivities(string userId);
    }
}
