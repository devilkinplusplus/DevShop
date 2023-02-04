using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DevShop.Application.Cqrs.Commands.User.SellerRole
{
    public class SellerRoleCommandHandler : IRequestHandler<SellerRoleCommandRequest, SellerRoleCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public SellerRoleCommandHandler(IUserService userService, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<SellerRoleCommandResponse> Handle(SellerRoleCommandRequest request, CancellationToken cancellationToken)
        {
           string userId= _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           AppUser user = await _userManager.FindByIdAsync(userId);

           var userRoles = await _userManager.GetRolesAsync(user); 
            foreach (var item in userRoles)
            {
                if(item == "Seller"){
                    return new(){Succeeded = false};
                }
            }

           bool result = await _userService.AssignRole(userId,"Seller");
           return new(){Succeeded = result};
        }
    }
}