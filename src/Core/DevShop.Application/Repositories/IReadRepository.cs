﻿using DevShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, int page = 1, int size = 10, params string[] includeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> filter=null, int page = 1, int size = 10);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(Guid id);
    }
}
