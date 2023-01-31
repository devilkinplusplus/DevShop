using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Role.AllRoles
{
    public class AllRolesHandler : IRequestHandler<AllRolesQuery, AllRolesQueryResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<AllRolesHandler> _logger;
        public AllRolesHandler(IRoleService roleService, ILogger<AllRolesHandler> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        public async Task<AllRolesQueryResponse> Handle(AllRolesQuery request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            var roles = await _roleService.GetRoles();
            if (roles.Count() == 0)
            {
                _logger.LogInformation("Cannot found role");
                errorList.Add(new() { Description = "Cannot found role", Code = "404" });
                return new() { Succeeded = false  , Errors =   errorList };
            }

            return new() { Succeeded = true, Roles = roles };
        }
    }
}
