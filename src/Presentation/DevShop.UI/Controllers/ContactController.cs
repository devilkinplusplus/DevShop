using DevShop.Application.Cqrs.Commands.Contacts.Create;
using DevShop.Application.Cqrs.Queries.Contacts.GetAll;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Send(Contact contact){
            var res = await _mediator.Send(new CreateContactCommandRequest(){Contact = contact});
            return Json(new {success = res.Succeeded});
        }
    }
}
