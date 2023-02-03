using DevShop.Domain.Entities.Common;
using DevShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Entities.Concrete
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public SubCatagory SubCatagory { get; set; }
        public Guid SubCatagoryId { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public float Rating { get; set; } = 0;
        public int View { get; set; } = 0;
        public float Discount { get; set; } = 0;//percentage
        public DateTime CreatedDate { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
