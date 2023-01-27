using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.UpdateRole
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleHandler(IRoleService roleService) => _roleService = roleService;

        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            if (request.Name is null)
                return false;
            bool result = await _roleService.EditAsync(request.Id, request.Name);
            return result;
        }

    }
}
