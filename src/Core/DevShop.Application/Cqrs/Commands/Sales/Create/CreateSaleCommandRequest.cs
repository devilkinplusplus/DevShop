using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Sales.Create
{
    public class CreateSaleCommandRequest:IRequest<CreateSaleCommandResponse>
    {
        public List<Guid> ProductId { get; set; }
        public float TotalAmount { get; set; }
    }
}
