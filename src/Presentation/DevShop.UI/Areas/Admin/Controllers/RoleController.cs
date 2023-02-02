using DevShop.Application.Cqrs.Commands.Role.CreateRole;
using DevShop.Application.Cqrs.Commands.Role.DeleteRole;
using DevShop.Application.Cqrs.Commands.Role.UpdateRole;
using DevShop.Application.Cqrs.Queries.Role.AllRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(IMediator mediator, RoleManager<IdentityRole> roleManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _mediator.Send(new AllRolesQuery() { Page = page, Size = 10 });
            if (result.Succeeded)
                return View(result.Roles);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(result.Roles);
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
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(name);
        }


        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole? data = await _roleManager.FindByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {
            UpdateRoleCommandResponse result = await _mediator.Send(new UpdateRoleCommand() 
            { Id = id, Name = name });
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            DeleteRoleCommandResponse result = await _mediator.Send(new DeleteRoleCommand() { Id = id });
            return Json(new { success = result.Succeeded });
        }
    }
}
