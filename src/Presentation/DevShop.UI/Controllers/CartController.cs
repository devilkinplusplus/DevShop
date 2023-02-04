using DevShop.Application.Cqrs.Commands.Carts.Create;
using DevShop.Application.Cqrs.Commands.Carts.Delete;
using DevShop.Application.Cqrs.Queries.Carts.GetAll;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var res = await _mediator.Send(new GetAllCartsQueryRequest() { Page = page, Size = 8 });
            if (res.Succeeded)
                return View(res.Carts);
            foreach (var item in res.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Create(Cart cart)
        {
            var res = await _mediator.Send(new CreateCartCommandRequest() { Cart = cart });
            return Json(new { success = res.Succeeded });
        }

        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var res = await _mediator.Send(new DeleteCartCommandRequest() { Id = id });
            return Json(new { success = res.Succeeded });
        }

    }
}
