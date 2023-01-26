using DevShop.Application.Abstractions.Services.Authentications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserHandler(IAuthService authService) => _authService = authService;

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsync(request.Email, request.Password);
            return new()
            {
                Succeeded = response.Succeeded,
                Message = response.Message,
            };
        }
    }
}
