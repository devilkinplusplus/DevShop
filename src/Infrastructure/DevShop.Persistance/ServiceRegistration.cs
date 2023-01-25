using DevShop.Application.Abstractions.Services;
using DevShop.Application.Abstractions.Services.Authentications;
using DevShop.Domain.Entities.Identity;
using DevShop.Persistance.Context;
using DevShop.Persistance.Services;
using DevShop.Persistance.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.ConnectionString);
            });
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
