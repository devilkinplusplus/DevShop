using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Wishlists.Create
{
    public class CreateWishCommandRequest:IRequest<CreateWishCommandResponse>
    {
        public Wishlist Wishlist { get; set; }
    }
}
