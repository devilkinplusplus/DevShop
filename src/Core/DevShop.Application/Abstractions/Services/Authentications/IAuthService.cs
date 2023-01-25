using DevShop.Application.DTOs.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services.Authentications
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(string email, string password);
    }
}
