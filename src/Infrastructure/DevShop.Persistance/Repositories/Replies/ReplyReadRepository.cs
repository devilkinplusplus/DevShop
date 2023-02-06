using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Repositories.Replies;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;

namespace DevShop.Persistance.Repositories.Replies
{
    public class ReplyReadRepository : ReadRepository<Reply>, IReplyReadRepository
    {
        public ReplyReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}