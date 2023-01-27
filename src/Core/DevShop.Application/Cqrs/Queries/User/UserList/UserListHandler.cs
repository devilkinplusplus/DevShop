using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.User.UserList
{
    public class UserListHandler : IRequestHandler<UserListQuery, UserListQueryResponse>
    {
        private readonly IUserService _userService;

        public UserListHandler(IUserService userService) => _userService = userService;

        public async Task<UserListQueryResponse> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AppUser> users = await _userService.GetUsers();
            if (users is null)
                return new() { Succeeded = false };
            return new() { Succeeded = true, Users = users };
        }
    }
}
