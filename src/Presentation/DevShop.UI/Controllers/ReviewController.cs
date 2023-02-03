using DevShop.Application.Cqrs.Commands.Reviews.Create;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<JsonResult> PostReview(Review review)
        {
            CreateReviewCommandResponse res = await _mediator.Send(new CreateReviewCommandRequest()
                                                                    { Review = review });
            return Json(res.Succeeded);
        }
    }
}
