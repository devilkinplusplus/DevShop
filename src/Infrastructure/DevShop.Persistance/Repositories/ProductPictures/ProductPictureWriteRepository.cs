using DevShop.Application.Repositories.ProductPictures;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.ProductPictures
{
    public class ProductPictureWriteRepository : WriteRepository<ProductPicture>, IProductPictureWriteRepository
    {
        public ProductPictureWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
