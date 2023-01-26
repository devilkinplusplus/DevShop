using DevShop.Application.Abstractions.Services;
using DevShop.Application.Abstractions.Services.Authentications;
using DevShop.Application.Cqrs.Commands.User.LoginUser;
using DevShop.Application.DTOs.Authentication;
using DevShop.Application.Validations;
using DevShop.Domain.Entities.Identity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthService(IUserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> LoginAsync(string email, string password)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                throw new Exception("User not found");

            SignInResult result = await _signInManager.PasswordSignInAsync(user, password, true, true);

            if (result.Succeeded)
            {
                return new() { Succeeded = result.Succeeded , Message = "Signed in successfully"};
            }
            return new() { Succeeded = result.Succeeded, Message = "Email or password is incorrect" };
        }

    }
}
