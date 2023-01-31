using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
        private readonly ILogger<CreateRoleCommandHandler> _logger;
        private readonly IRoleService _roleService;
        public CreateRoleCommandHandler(IRoleService roleService, ILogger<CreateRoleCommandHandler> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            if(request.Name is null)
            {
                errorList.Add(new IdentityError() { Code = "404", Description = "Role name cannot be null" });
                return new() { Succeeded = false ,Errors = errorList};
            }
            bool result = await _roleService.CreateAsync(request.Name);
            if (!result)
            {
                _logger.LogInformation("Cannot create role");
                errorList.Add(new() { Code="401",Description = "An error occured while creating new role" });
                return new() { Succeeded = false, Errors = errorList};
            }
            return new() { Succeeded = result };
        }
    }
}
