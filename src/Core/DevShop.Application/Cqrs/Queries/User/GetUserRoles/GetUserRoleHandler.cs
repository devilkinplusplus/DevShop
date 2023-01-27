using DevShop.Application.Abstractions.Services;
using MediatR;

namespace DevShop.Application.Cqrs.Queries.User.GetUserRoles
{
    public class GetUserRoleHandler : IRequestHandler<GetUserRolesQuery, GetUserRolesQueryResponse>
    {
        private readonly IUserService _userService;
        public GetUserRoleHandler(IUserService userService) => _userService = userService;

        public async Task<GetUserRolesQueryResponse> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetUserRoles(request.Id);
            return new() { UserRoleVM = response };
        }
    }
}
