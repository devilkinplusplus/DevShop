using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Catagories.DeleteCatagory
{
    public class DeleteCatagoryCommand:IRequest<DeleteCatagoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
