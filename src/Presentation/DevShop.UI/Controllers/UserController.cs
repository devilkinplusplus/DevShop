using System.Security.Claims;
using DevShop.Application.Cqrs.Commands.User.ChangePassword;
using DevShop.Application.Cqrs.Commands.User.UploadPhoto;
using DevShop.Application.Cqrs.Queries.Sales.LastActions;
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
        private readonly IHttpContextAccessor _contextAccessor;
        public UserController(IMediator mediator, IWebHostEnvironment environment, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _environment = environment;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRes = await _mediator.Send(new GetCurrentUserQueryRequest());
            var salesRes = await _mediator.Send(new LastActionsQueryRequest(){UserId = userId});
            UserVM userVM = new() { User = userRes.AppUser };
            if(salesRes.Succeeded){
                userVM.Sales = salesRes.Sales;
            }
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
