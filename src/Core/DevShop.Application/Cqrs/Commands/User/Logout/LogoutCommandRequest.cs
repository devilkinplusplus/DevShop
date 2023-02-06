using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace DevShop.Application.Cqrs.Commands.User.Logout
{
    public class LogoutCommandRequest:IRequest<LogoutCommandResponse>
    {
    }
}