using DevShop.Application.Cqrs.Commands.User.CreateUser;
using DevShop.Application.DTOs.User;
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
    }
}
