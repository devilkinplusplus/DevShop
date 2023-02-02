using DevShop.Application.Consts;
using DevShop.Application.Cqrs.Commands.Products.Create;
using DevShop.Application.Cqrs.Commands.Products.Delete;
using DevShop.Application.Cqrs.Commands.Products.Update;
using DevShop.Application.Cqrs.Queries.Products.GetById;
using DevShop.Application.Cqrs.Queries.Products.GetMyProducts;
using DevShop.Application.Cqrs.Queries.Subcatagories.GetAll;
using DevShop.Application.Cqrs.Queries.Subcatagories.GetById;
using DevShop.Application.DTOs.Products;
using DevShop.Application.Repositories.ProductPictures;
using DevShop.Application.Repositories.Products;
using DevShop.Application.ViewModels;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            GetMyProductsQueryResponse res = await _mediator.Send(new GetMyProductsQueryRequest()
            { Page = page, Size = 10 });
            if (res.Succeeded)
            {
                return View(res.Products);
            }
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var subcatagories = await _mediator.Send(new AllSubcatagoriesQuery() { Page = 1, Size = 10 });
            if (subcatagories.Succeeded)
                return View(subcatagories.SubCatagories);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, List<string> pictureIds)
        {
            var subcatagories = await _mediator.Send(new AllSubcatagoriesQuery() { Page = 1, Size = 10 });

            ProductCreateCommandResponse res = await _mediator.Send(new ProductCreateCommandRequest()
            { Product = product, PictureIds = pictureIds });

            if (res.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            if (subcatagories.Succeeded)
                return View(subcatagories.SubCatagories);
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            GetProductQueryResponse res = await _mediator.Send(new GetProductQueryRequest() { Id = id });
            var subcatagories = await _mediator.Send(new AllSubcatagoriesQuery() { Page =1 ,Size =10});
            if (res.Succeeded && subcatagories.Succeeded)
            {
                //Need to send product and their subcatagory
                EditProductVM editProduct = new()
                {
                    Product = res.Product,
                    SubCatagories = subcatagories.SubCatagories
                };
                return View(editProduct);
            }
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO model, Guid id)
        {
            //for failed submissions
            var subcatagories = await _mediator.Send(new AllSubcatagoriesQuery() { Page = 1, Size = 10 });
            UpdateProductCommandResponse res = await _mediator.Send(new UpdateProductCommandRequest()
            { Id = id, ProductDto = model });

            if (res.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            if (subcatagories.Succeeded)
            {
                EditProductVM editProductVM = new() { Product = res.Product, SubCatagories = subcatagories.SubCatagories };
                return View(editProductVM);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var res = await _mediator.Send(new DeleteProductCommandRequest() { Id = id });
            return Json(new { success = res.Succeeded });
        }

    }
}
