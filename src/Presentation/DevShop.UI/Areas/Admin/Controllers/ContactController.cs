using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Cqrs.Commands.Contacts.Delete;
using DevShop.Application.Cqrs.Commands.Replies.Create;
using DevShop.Application.Cqrs.Queries.Contacts.GetAll;
using DevShop.Application.Cqrs.Queries.Contacts.GetById;
using DevShop.Application.Cqrs.Queries.Replies.GetAll;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
       private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int page = 1){
            var res = await _mediator.Send(new GetAllContactsQueryRequest(){Page = page,Size = 10});
            if(res.Succeeded)
                return View(res.Contacts);
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }
            return View();
        }

        public async Task<IActionResult> Reply(Guid id){
            var data = await _mediator.Send(new GetContactByIdQueryRequest(){Id = id});
            return View(data.Contact);
        }

        [HttpPost]
        public async Task<IActionResult> Reply(Guid id,Reply reply){
            reply.Id = Guid.NewGuid();//for conflicts
            var res = await _mediator.Send(new CreateReplyCommandRequest(){ContactId = id,Reply = reply});

            if(res.Succeeded){
                return RedirectToAction(nameof(Index));
            }
            foreach (var item in res.Errors)
            {
                ModelState.AddModelError("",item.ErrorMessage);
            }
            return View();
        }

         [HttpPost]
        public async Task<JsonResult> Delete(Guid id){
            var res = await _mediator.Send(new DeleteContactCommandRequest(){Id = id});
            return Json(new{success = res.Succeeded});
        }


    }
}