using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.DeleteRole
{
    public class DeleteRoleCommand:IRequest<DeleteRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}
