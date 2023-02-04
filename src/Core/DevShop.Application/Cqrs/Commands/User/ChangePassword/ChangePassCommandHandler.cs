using DevShop.Application.Abstractions.Services;
using DevShop.Application.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.ChangePassword
{
    public class ChangePassCommandHandler : IRequestHandler<ChangePassCommandRequest, ChangePassCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ChangePassCommandHandler(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }

        public async Task<ChangePassCommandResponse> Handle(ChangePassCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.PasswordDTO.Password != request.PasswordDTO.RePassword)
                return new() { Succeeded = false };
            if(request.PasswordDTO.Password is null || request.PasswordDTO.RePassword is null)
                return new() { Succeeded = false };

            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            PasswordResponse response = await _userService
                                        .ChangePassword(userId,request.PasswordDTO.Password);
            if (response.Succeeded)
            {
                await _userService.UpdatePassword(response.User);
                return new() { Succeeded = true };
            }
            return new() { Succeeded = false};
        }
    }
}
