using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandResponse : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandResponse(IRoleService roleService) => _roleService = roleService;

        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            if (request.Id is null)
                return false;
            return await _roleService.DeleteAsync(request.Id);
        }
    }
}
