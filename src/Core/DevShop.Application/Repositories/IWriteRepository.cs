using DevShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T: BaseEntity
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        Task<bool> RemoveRangeAsync(List<T> entities);
    }
}
