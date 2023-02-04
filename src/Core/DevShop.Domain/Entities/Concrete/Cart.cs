using DevShop.Domain.Entities.Common;
using DevShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Entities.Concrete
{
    public class Cart:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int Quantity { get; set; }
    }
}
