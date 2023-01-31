using DevShop.Application.Repositories.Pictures;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Pictures
{
    public class PictureReadRepository : ReadRepository<Picture>, IPictureReadRepository
    {
        public PictureReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
