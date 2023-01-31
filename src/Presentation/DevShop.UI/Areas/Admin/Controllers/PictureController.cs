using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PictureController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPictureService _pictureService;

        public PictureController(IWebHostEnvironment env, IPictureService pictureService)
        {
            _env = env;
            _pictureService = pictureService;
        }
        [HttpPost]
        public async Task<JsonResult> Upload(List<IFormFile> pictures)
        {
            var pictureResult = await _pictureService.AddPicture(pictures, _env.WebRootPath);
            if(pictureResult.Count != 0)
                return Json(pictureResult);
            return Json(null);
        }
    }
}
