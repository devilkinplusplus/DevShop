using DevShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.DTOs.Authentication
{
    public class PasswordResponse
    {
        public AppUser User { get; set; }
        public bool Succeeded { get; set; }
    }
}
