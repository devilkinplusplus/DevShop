using DevShop.Application.Cqrs.Commands.User.AssignRole;
using DevShop.Application.Cqrs.Commands.User.CreateUser;
using DevShop.Application.Cqrs.Commands.User.LoginUser;
using DevShop.Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUser model)
        {
            CreateUserCommandResponse response = await _mediator.Send(new CreateUserCommand()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password
            });
            if (response.Succeeded)
            {
                await _mediator.Send(new AssignRoleCommand() { Id = response.User.Id, Role = "User" });
                _logger.LogInformation("New user registered");
                return RedirectToAction(nameof(Login));
            }
           
            foreach (var error in response.Messages)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin model)
        {
            LoginUserCommandResponse response = await _mediator.Send(new LoginUserCommand()
            { Email = model.Email, Password = model.Password });
            if (response.Succeeded)
                return RedirectToAction("Index","Home");
            foreach (var item in response.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }
    }
}
