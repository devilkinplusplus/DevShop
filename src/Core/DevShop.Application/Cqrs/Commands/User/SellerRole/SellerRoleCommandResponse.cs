using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DevShop.Application.Cqrs.Commands.User.SellerRole
{
    public class SellerRoleCommandResponse
    {
        public bool Succeeded { get; set; }
    }
}