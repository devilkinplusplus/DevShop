using DevShop.Application.Repositories;
using DevShop.Domain.Entities.Common;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public ReadRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? await _appDbContext.Set<T>().ToListAsync() :
                                await _appDbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _appDbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
           return await _appDbContext.Set<T>().FindAsync(id);
        }
    }
}
