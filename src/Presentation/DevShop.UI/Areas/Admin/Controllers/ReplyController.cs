using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Cqrs.Commands.Replies.Delete;
using DevShop.Application.Cqrs.Queries.Replies.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReplyController:Controller
    {
        private readonly IMediator _mediator;
        public ReplyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int page = 1){
            var res = await _mediator.Send(new GetAllRepliesQueryRequest(){Page = page,Size = 12});
            if(res.Succeeded)
                return View(res.Replies);
            foreach (var item in res.Errors)
            {
                ModelState.AddModelError("",item.Description);
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Archive(Guid id){
            var res = await _mediator.Send(new DeleteReplyCommandRequest(){Id = id});
            return Json(new{success = res.Succeeded});
        }


    }
}