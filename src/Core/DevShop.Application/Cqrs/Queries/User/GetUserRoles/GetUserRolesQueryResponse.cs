using DevShop.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.User.GetUserRoles
{
    public class GetUserRolesQueryResponse
    {
        public AddUserRoleVM UserRoleVM { get; set; }
        public bool Succeeded { get; set; }
        public List<IdentityError> Errors { get; set; }
    }
}
