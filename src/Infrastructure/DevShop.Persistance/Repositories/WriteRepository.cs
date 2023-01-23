using DevShop.Application.Repositories;
using DevShop.Domain.Entities.Common;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public WriteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await _appDbContext.Set<T>().AddRangeAsync(entities);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> RemoveRangeAsync(List<T> entities)
        {
            _appDbContext.Set<T>().RemoveRange(entities);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
