using DevShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Repositories
{
    public interface IRepository<T> where T:BaseEntity
    {
    }
}
