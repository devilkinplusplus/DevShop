using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.UpdateRole
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<UpdateRoleHandler> _logger;
        public UpdateRoleHandler(IRoleService roleService, ILogger<UpdateRoleHandler> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            if (request.Name is null)
            {
                errorList.Add(new() { Code = "404", Description = "Role name cannot be null" });
                return new() { Succeeded = false,Errors = errorList};
            }
            bool result = await _roleService.EditAsync(request.Id, request.Name);
            if (!result)
            {
                _logger.LogInformation("Can't edit role name");
                errorList.Add(new() { Description = "An error occured while editing" });
                return new() { Succeeded = false, Errors = errorList };
            }
            return new() { Succeeded =true};
        }

    }
}
