using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DevShop.Application.Cqrs.Commands.Sales.Create;
using DevShop.Application.Cqrs.Commands.User.SellerRole;
using DevShop.Application.Cqrs.Queries.Sales.GetMyPurschaes;
using DevShop.Application.Cqrs.Queries.Sales.GetMySales;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevShop.UI.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        public SellerController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
        }
        //My sales
        public async Task<IActionResult> Index(int page = 1)
        {
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _mediator.Send(new GetMySalesQueryRequest() { UserId = userId ,Page =page,Size = 10});
            if(res.Succeeded)
                return View(res.Sales);
            foreach (var item in res.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }

        //My Buys
        public async Task<IActionResult> MyBuys(int page = 1)
        {
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _mediator.Send(new GetMyBuysQueryRequest() { UserId = userId ,Page =page,Size = 10});
            if(res.Succeeded)
                return View(res.Sales);
            foreach (var item in res.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> BecomeSeller()
        {
            var res = await _mediator.Send(new SellerRoleCommandRequest());
            return Json(new { success = res.Succeeded });
        }

        [HttpPost]
        public async Task<JsonResult> BuyProduct(List<Guid> productsId, float totalAmount)
        {
            var saleRes = await _mediator.Send(new CreateSaleCommandRequest()
            { ProductId = productsId, TotalAmount = totalAmount });
            return Json(new { success = saleRes.Succeeded });
        }
    }
}