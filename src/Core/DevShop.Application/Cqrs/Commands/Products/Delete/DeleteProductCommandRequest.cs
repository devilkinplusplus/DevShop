using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Products.Delete
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
