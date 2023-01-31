using DevShop.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.AssignRole
{
    public class AssignRoleCommandResponse
    {
        public bool Succeeded { get; set; }
        public List<IdentityError> Errors { get; set; }
    }
}
