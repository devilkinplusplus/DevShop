using DevShop.Application.Abstractions.Services.Authentications;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;

        public async Task<bool> CreateAsync(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Name = name });
            return result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            IdentityRole data = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(data);
            return result.Succeeded;
        }

        public async Task<bool> EditAsync(string id, string name)
        {
            IdentityRole data = await _roleManager.FindByIdAsync(id);
            data.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(data);
            return result.Succeeded;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.AsNoTracking().ToListAsync();
        }
    }
}
