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
using X.PagedList;

namespace DevShop.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public ReadRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
            int page = 1, int size = 10)
        {
            return filter == null ? await _appDbContext.Set<T>().ToPagedListAsync(page,size) :
                                await _appDbContext.Set<T>().Where(filter).ToPagedListAsync(page, size);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, int page = 1, 
                    int size = 10, params string[] includeProperties)
        {
            var query = _appDbContext.Set<T>().AsQueryable();

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return filter == null ? await query.ToPagedListAsync(page,size) :
                        await query.Where(filter).ToPagedListAsync(page ,size);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _appDbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            var query = _appDbContext.Set<T>().AsQueryable();

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }
    }
}
