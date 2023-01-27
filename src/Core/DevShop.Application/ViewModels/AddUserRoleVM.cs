using DevShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.ViewModels
{
    public class AddUserRoleVM
    {
        public AppUser User { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool Succeeded { get; set; }
    }
}
