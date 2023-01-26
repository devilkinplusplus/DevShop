using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;
        public CreateRoleCommandHandler(IRoleService roleService) => _roleService = roleService;

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if(request.Name is null)
                return new() { Succeeded = false };
            bool result = await _roleService.CreateAsync(request.Name);
            return new() { Succeeded = result };
        }
    }
}
