using DevShop.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DevShop.Application.Cqrs.Queries.User.GetUserRoles
{
    public class GetUserRoleHandler : IRequestHandler<GetUserRolesQuery, GetUserRolesQueryResponse>
    {
        private readonly IUserService _userService;
        public GetUserRoleHandler(IUserService userService) => _userService = userService;

        public async Task<GetUserRolesQueryResponse> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            var response = await _userService.GetUserRoles(request.Id);
            if(response is null)
            {
                errorList.Add(new() { Code = "404", Description = "No item found" });
                return new() { Succeeded = false ,Errors = errorList};
            }
            return new() { UserRoleVM = response ,Succeeded = true};
        }
    }
}
