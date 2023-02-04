using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Wishlists.Delete
{
    public class DeleteWishCommandRequest:IRequest<DeleteWishCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
