using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DevShop.Application.Cqrs.Commands.User.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommandRequest, LogoutCommandResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutCommandHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LogoutCommandResponse> Handle(LogoutCommandRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return new(){Succeeded = true};
        }
    }
}