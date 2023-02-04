using DevShop.Application.Cqrs.Commands.User.ChangePassword;
using DevShop.Application.Cqrs.Commands.User.UploadPhoto;
using DevShop.Application.Cqrs.Queries.User.GetCurrent;
using DevShop.Application.DTOs.User;
using DevShop.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _environment;
        public UserController(IMediator mediator, IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var userRes = await _mediator.Send(new GetCurrentUserQueryRequest());
            UserVM userVM = new() { User = userRes.AppUser };

            return View(userVM);
        }

        [HttpPost]
        public async Task<JsonResult> ChangePassword(ChangePasswordDTO model)
        {
            var res = await _mediator.Send(new ChangePassCommandRequest() { PasswordDTO = model });
            return Json(new { success = res.Succeeded });
        }

        [HttpPost]
        public async Task<JsonResult> UploadPhoto(IFormFile picture)
        {
            string WebRootPath = _environment.WebRootPath;
            var res = await _mediator.Send(new UploadPhotoCommandRequest(){Photo = picture,WebRootPath = WebRootPath});
            return Json(new{success = res.Succeeded});
        }


    }
}
