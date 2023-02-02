using DevShop.Application.Cqrs.Commands.Role.CreateRole;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services.Authentications
{
    public interface IRoleService
    {
        Task<bool> CreateAsync(string name);
        Task<IEnumerable<IdentityRole>> GetRoles(int page = 1, int size = 10);
        Task<bool> EditAsync(string id,string name);
        Task<bool> DeleteAsync(string id);
    }
}
