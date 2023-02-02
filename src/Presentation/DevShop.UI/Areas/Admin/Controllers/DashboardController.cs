using DevShop.Application.Cqrs.Queries.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest() { Page = page, Size = 10 });
            if (response.Succeeded)
                return View(response.Products);
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
    }
}
