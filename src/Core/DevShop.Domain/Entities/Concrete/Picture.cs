using DevShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Entities.Concrete
{
    public class Picture : BaseEntity
    {
        public string ImageUrl { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
    }
}
