using DevShop.Application.Cqrs.Commands.User.CreateUser;
using DevShop.Application.DTOs.Authentication;
using DevShop.Application.DTOs.User;
using DevShop.Application.ViewModels;
using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateAsync(CreateUser model);
        string AddPhoto(IFormFile Picture, string webrootpath);
        Task<bool> UpdatePassword(AppUser user);
        Task<bool> UpdatePhoto(string userId,string photoUrl);
        Task<IEnumerable<AppUser>> GetUsers(int page = 1, int size = 10);
        Task<AddUserRoleVM> GetUserRoles(string id);
        Task<bool> AssignRole(string id, string role);
        Task<PasswordResponse> ChangePassword(string userId,string password);
        Task<bool> IsEmailExist(string email);
    }
}
