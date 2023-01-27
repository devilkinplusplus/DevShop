using DevShop.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.AssignRole
{
    public class AssignRoleHandler : IRequestHandler<AssignRoleCommand, AssignRoleCommandResponse>
    {
        private readonly IUserService _userService;
        public AssignRoleHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AssignRoleCommandResponse> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            bool result = await _userService.AssignRole(request.Id, request.Role);
            return new() { Succeeded  = result };
        }
    }
}
