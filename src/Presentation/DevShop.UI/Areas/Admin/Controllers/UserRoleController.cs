using DevShop.Application.Cqrs.Commands.User.AssignRole;
using DevShop.Application.Cqrs.Queries.User;
using DevShop.Application.Cqrs.Queries.User.GetUserRoles;
using DevShop.Application.Cqrs.Queries.User.UserList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private readonly IMediator _mediator;

        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = await _mediator.Send(new UserListQuery());
            if (query.Succeeded)
                return View(query.Users);
            return View();
        }

        public async Task<IActionResult> AddRole(string id)
        {
            GetUserRolesQueryResponse response = await _mediator.Send(new GetUserRolesQuery() 
            { Id = id });
            return View(response.UserRoleVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id , string role)
        {
           AssignRoleCommandResponse response= await _mediator.Send(new AssignRoleCommand() 
           { Id = id, Role = role });
            if(response.Succeeded)
                return RedirectToAction(nameof(Index));
            return View();
        }

    }
}
