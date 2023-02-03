using DevShop.Application.Repositories.Reviews;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Reviews
{
    public class ReviewWriteRepository : WriteRepository<Review>, IReviewWriteRepository
    {
        public ReviewWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
