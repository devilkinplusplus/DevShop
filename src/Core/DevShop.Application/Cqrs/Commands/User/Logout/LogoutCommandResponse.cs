using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.Logout
{
    public class LogoutCommandResponse
    {
        public bool Succeeded { get; set; }
    }
}