using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Contacts.Create
{
    public class CreateContactCommandRequest:IRequest<CreateContactCommandResponse>
    {
        public Contact Contact { get; set; }
    }
}
