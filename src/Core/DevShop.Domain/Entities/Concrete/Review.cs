using DevShop.Domain.Entities.Common;
using DevShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Entities.Concrete
{
    public class Review : BaseEntity
    {
        public string Comment { get; set; }
        public float? Rating { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
    }
}
