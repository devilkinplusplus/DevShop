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

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
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
                return RedirectToAction(nameof(Login));
            else
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(model);
            }
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
                return RedirectToAction(nameof(Register));
            else
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }
        }
    }
}
