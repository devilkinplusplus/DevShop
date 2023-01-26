using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Role.AllRoles
{
    public class AllRolesHandler : IRequestHandler<AllRolesQuery, IEnumerable<IdentityRole>>
    {
        private readonly IRoleService _roleService;

        public AllRolesHandler(IRoleService roleService) => _roleService = roleService;

        public async Task<IEnumerable<IdentityRole>> Handle(AllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetRoles();
            return roles;
        }
    }
}
