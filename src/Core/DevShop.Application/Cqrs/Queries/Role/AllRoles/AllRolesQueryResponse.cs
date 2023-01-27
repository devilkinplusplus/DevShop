using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Role.AllRoles
{
    public class AllRolesQueryResponse
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
        public bool Succeeded { get; set; }
    }
}
