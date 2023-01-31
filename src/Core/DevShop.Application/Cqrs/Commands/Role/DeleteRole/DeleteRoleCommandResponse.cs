using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandResponse
    {
        public bool Succeeded { get; set; }
        public List<IdentityError> Errors { get; set; }
    }
}
