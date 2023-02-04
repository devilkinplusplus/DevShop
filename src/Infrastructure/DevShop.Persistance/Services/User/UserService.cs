using AutoMapper;
using DevShop.Application.Abstractions.Services;
using DevShop.Application.Cqrs.Commands.User.CreateUser;
using DevShop.Application.DTOs.Authentication;
using DevShop.Application.DTOs.User;
using DevShop.Application.Helpers.Utilities.FileHelper;
using DevShop.Application.Repositories;
using DevShop.Application.Validations;
using DevShop.Application.ViewModels;
using DevShop.Domain.Entities.Identity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DevShop.Persistance.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPasswordValidator<AppUser> _passwordValidator;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, IPasswordValidator<AppUser> passwordValidator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _passwordValidator = passwordValidator;
        }

        public async Task<AddUserRoleVM> GetUserRoles(string id)
        {
            if (id is null)
                return new() { Succeeded = false };

            AppUser user = await _userManager.FindByIdAsync(id);
            if (user is null)
                return new() { Succeeded = false };

            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            var roles = _roleManager.Roles.Select(role => role.Name).ToList();

            return new() { Succeeded = true, Roles = roles.Except(userRoles), User = user };

        }

        public async Task<CreateUserCommandResponse> CreateAsync(CreateUser model)
        {
            var mapper = _mapper.Map<AppUser>(model);

            UserValidator validationRules = new UserValidator();
            ValidationResult results = validationRules.Validate(mapper);

            if (results.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(new()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Username,
                }, model.Password);

                AppUser data = await _userManager.FindByEmailAsync(mapper.Email);
                CreateUserCommandResponse response = new() { Succeeded = result.Succeeded, User = data };

                if (!result.Succeeded)
                {
                    response.Messages = result.Errors;
                    response.Succeeded = false;
                }

                return response;
            }
            return new() { Succeeded = false, Errors = results.Errors };
        }

        public async Task<IEnumerable<AppUser>> GetUsers(int page = 1, int size = 10)
        {
            return await _userManager.Users.ToPagedListAsync(page, size);
        }

        public async Task<bool> AssignRole(string id, string role)
        {
            if (id is null) return false;

            AppUser? user = await _userManager.FindByIdAsync(id);
            if (user is null) return false;

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.Succeeded;
        }

        public async Task<PasswordResponse> ChangePassword(string userId, string password)
        {
            AppUser currentUser = await _userManager.FindByIdAsync(userId);
            var newHashedPass = _userManager.PasswordHasher.HashPassword(currentUser, password);

            currentUser.PasswordHash = newHashedPass;
            var isPasswordCorrect = await _passwordValidator
                                        .ValidateAsync(_userManager, currentUser, password);
            if (isPasswordCorrect.Succeeded)
            {
                return new() { Succeeded = true, User = currentUser };
            }
            return new() { Succeeded = false };
        }

        public async Task<bool> UpdatePassword(AppUser user)
        {
            await _userManager.UpdateAsync(user);
            return true;
        }

        public string AddPhoto(IFormFile Picture, string webrootpath)
        {
            return Picture.UploadProfilePhoto(webrootpath);
        }

        public async Task<bool> UpdatePhoto(string userId, string photoUrl)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            user.ProfilePhoto = photoUrl;
            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}
