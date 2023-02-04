using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Wishlists.GetAll
{
    public class GetAllWishesQueryResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<Wishlist> Wishlists { get; set; }
    }
}
