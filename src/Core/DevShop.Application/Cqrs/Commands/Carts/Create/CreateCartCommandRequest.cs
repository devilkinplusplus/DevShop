using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Carts.Create
{
    public class CreateCartCommandRequest:IRequest<CreateCartCommandResponse>
    {
        public Cart Cart { get; set; }
    }
}
