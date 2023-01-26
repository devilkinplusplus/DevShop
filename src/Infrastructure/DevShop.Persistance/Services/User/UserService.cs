using AutoMapper;
using DevShop.Application.Abstractions.Services;
using DevShop.Application.Cqrs.Commands.User.CreateUser;
using DevShop.Application.DTOs.User;
using DevShop.Application.Repositories;
using DevShop.Application.Validations;
using DevShop.Domain.Entities.Identity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
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

                CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };
                if (result.Succeeded)
                    response.Message = "User created succesfully";
                else
                    foreach (var error in result.Errors)
                        response.Message = $"{error.Code} - {error.Description}";
                return response;
            }
            return new() { Succeeded = false,  Errors = results.Errors };
        }
    }
}
