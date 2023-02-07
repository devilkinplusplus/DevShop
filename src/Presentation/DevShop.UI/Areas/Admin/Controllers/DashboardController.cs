using DevShop.Application.Cqrs.Queries.Products.GetAllProducts;
using DevShop.Persistance.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;
        public DashboardController(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            StatsForDashboard();
            var response = await _mediator.Send(new GetAllProductsQueryRequest() { Page = page, Size = 10 });
            if (response.Succeeded)
                return View(response.Products);
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        [NonAction]
        public void StatsForDashboard()
        {
            ViewBag.totalSales = _context.Sales.Where(x=>x.IsDeleted == false)
                        .Include(x => x.Product).Sum(x => x.Product.Price);
            ViewBag.visitors = _context.Users.Count();
            ViewBag.salesCount = _context.Sales.Where(x=>x.IsDeleted ==false).Count();
        }

    }
}
