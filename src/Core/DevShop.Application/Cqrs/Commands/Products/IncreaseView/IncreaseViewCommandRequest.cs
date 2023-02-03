using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Products.IncreaseView
{
    public class IncreaseViewCommandRequest:IRequest<IncreaseViewCommandResponse>
    {
        public Guid ProductId { get; set; }
    }
}
