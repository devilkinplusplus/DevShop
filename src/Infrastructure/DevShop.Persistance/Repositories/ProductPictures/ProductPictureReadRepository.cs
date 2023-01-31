using DevShop.Application.Repositories.ProductPictures;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.ProductPictures
{
    public class ProductPictureReadRepository : ReadRepository<ProductPicture>,IProductPictureReadRepository
    {
        public ProductPictureReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
