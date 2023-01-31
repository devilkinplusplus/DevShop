using DevShop.Application.Cqrs.Commands.Products.Create;
using DevShop.Application.Cqrs.Queries.Subcatagories.GetAll;
using DevShop.Application.DTOs.Products;
using DevShop.Application.Repositories.ProductPictures;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProductPictureWriteRepository _productPictureWrite;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductWriteRepository _productWrite;
        public ProductController(IMediator mediator, IProductPictureWriteRepository productPictureWrite, IHttpContextAccessor httpContextAccessor, IProductWriteRepository productWrite)
        {
            _mediator = mediator;
            _productPictureWrite = productPictureWrite;
            _httpContextAccessor = httpContextAccessor;
            _productWrite = productWrite;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var subcatagories = await _mediator.Send(new AllSubcatagoriesQuery());
            if (subcatagories.Succeeded)
                return View(subcatagories.SubCatagories);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, List<string> pictureIds)
        {
            var subcatagories = await _mediator.Send(new AllSubcatagoriesQuery());

            ProductCreateCommandResponse res = await _mediator.Send(new ProductCreateCommandRequest() 
            { Product = product, PictureIds = pictureIds });

            if(res.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }
            if(subcatagories.Succeeded)
                return View(subcatagories.SubCatagories);
            return View();
        }

    }
}
