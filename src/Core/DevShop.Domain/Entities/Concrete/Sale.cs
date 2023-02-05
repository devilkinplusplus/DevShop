using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Common;
using DevShop.Domain.Entities.Identity;

namespace DevShop.Domain.Entities.Concrete
{
    public class Sale:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string BuyerId { get; set; }
        public AppUser Buyer { get; set; }
        public string SellerId { get; set; }
        public AppUser Seller { get; set; }
        public DateTime SaleDate { get; set; }
    }
}