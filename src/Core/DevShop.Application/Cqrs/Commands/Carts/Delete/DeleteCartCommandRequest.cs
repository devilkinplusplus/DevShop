using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Carts.Delete
{
    public class DeleteCartCommandRequest:IRequest<DeleteCartCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
