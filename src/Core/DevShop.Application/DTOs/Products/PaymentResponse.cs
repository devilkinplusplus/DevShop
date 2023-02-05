using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.DTOs.Products
{
    public class PaymentResponse
    {
        public List<string> SellerIds { get; set; }
        public List<Guid> ProductIds { get; set; }
    }
}
