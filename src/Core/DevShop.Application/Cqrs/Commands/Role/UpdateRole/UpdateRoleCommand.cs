using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.UpdateRole
{
    public class UpdateRoleCommand : IRequest<UpdateRoleCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
