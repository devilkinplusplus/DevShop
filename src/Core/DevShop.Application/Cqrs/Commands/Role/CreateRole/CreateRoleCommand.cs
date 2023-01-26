using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.CreateRole
{
    public class CreateRoleCommand:IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set;}
    }
}
