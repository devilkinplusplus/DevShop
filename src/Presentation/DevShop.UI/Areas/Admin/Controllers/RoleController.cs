using DevShop.Application.Cqrs.Commands.Role.CreateRole;
using DevShop.Application.Cqrs.Queries.Role.AllRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<IdentityRole> result = await _mediator.Send(new AllRolesQuery());
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            CreateRoleCommandResponse response = await _mediator.Send(new CreateRoleCommand() { Name = name });
            if (response.Succeeded)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", "An error occured");
            return View(name);
        }
    }
}
