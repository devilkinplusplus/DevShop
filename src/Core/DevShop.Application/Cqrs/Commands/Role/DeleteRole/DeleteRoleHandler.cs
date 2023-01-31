using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.DeleteRole
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<DeleteRoleHandler> _logger;
        public DeleteRoleHandler(IRoleService roleService, ILogger<DeleteRoleHandler> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            if (request.Id is null)
            {
                _logger.LogInformation("Id is null , can't delete role");
                errorList.Add(new() { Code = "404", Description = "Id is null" });
                return new() { Succeeded = false, Errors = errorList };
            }

            bool result = await _roleService.DeleteAsync(request.Id);
            if (!result)
            {
                _logger.LogInformation("Cannot delete role");
                errorList.Add(new() { Code = "404", Description = "Cannot delete this role" });
                return new() { Succeeded = false ,Errors = errorList};
            }

            return new() { Succeeded = true };
        }
    }
}
