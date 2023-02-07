using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Contacts.Delete
{
    public class DeleteContactCommandRequest:IRequest<DeleteContactCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
