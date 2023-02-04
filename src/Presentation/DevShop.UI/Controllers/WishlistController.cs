using DevShop.Application.Cqrs.Commands.Wishlists.Create;
using DevShop.Application.Cqrs.Commands.Wishlists.Delete;
using DevShop.Application.Cqrs.Queries.Wishlists.GetAll;
using DevShop.Domain.Entities.Concrete;
using JetBrains.Annotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IMediator _mediator;

        public WishlistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var res = await _mediator.Send(new GetAllWishesQueryRequest() { Page = page, Size = 8 });
            if (res.Succeeded)
                return View(res.Wishlists);
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create(Wishlist wishlist)
        {
            var res = await _mediator.Send(new CreateWishCommandRequest() { Wishlist = wishlist });
            return Json(new { success = res.Succeeded });
        }

        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var res = await _mediator.Send(new DeleteWishCommandRequest() { Id = id });
            return Json(new { success = res.Succeeded });
        }
    }
}
