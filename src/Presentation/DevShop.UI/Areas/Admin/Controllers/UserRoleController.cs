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

        public async Task<IActionResult> Index(int page = 1)
        {
            var query = await _mediator.Send(new UserListQuery() { Page = page, Size = 10 });
            if (query.Succeeded)
                return View(query.Users);
            foreach (var error in query.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        public async Task<IActionResult> AddRole(string id)
        {
            GetUserRolesQueryResponse response = await _mediator.Send(new GetUserRolesQuery()
            { Id = id });
            if (response.Succeeded)
                return View(response.UserRoleVM);
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {
            AssignRoleCommandResponse response = await _mediator.Send(new AssignRoleCommand()
            { Id = id, Role = role });
            if (response.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

    }
}
