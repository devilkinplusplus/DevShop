using DevShop.Application.Cqrs.Commands.User.CreateUser;
using DevShop.Application.DTOs.User;
using DevShop.Application.ViewModels;
using DevShop.Domain.Entities.Identity;
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
        Task<IEnumerable<AppUser>> GetUsers();
        Task<AddUserRoleVM> GetUserRoles(string id);
        Task<bool> AssignRole(string id, string role);

    }
}
