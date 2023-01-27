using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.AssignRole
{
    public class AssignRoleCommand:IRequest<AssignRoleCommandResponse>
    {
        public string Id { get; set; }
        public string Role { get; set; }
    }
}
