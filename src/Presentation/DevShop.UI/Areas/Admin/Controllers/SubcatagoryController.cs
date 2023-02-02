using Azure;
using DevShop.Application.Cqrs.Commands.Subcatagories.Create;
using DevShop.Application.Cqrs.Commands.Subcatagories.Delete;
using DevShop.Application.Cqrs.Commands.Subcatagories.Update;
using DevShop.Application.Cqrs.Queries.Catagories.CatagoryList;
using DevShop.Application.Cqrs.Queries.Subcatagories.GetAll;
using DevShop.Application.Cqrs.Queries.Subcatagories.GetById;
using DevShop.Application.DTOs.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubcatagoryController : Controller
    {
        private readonly IMediator _mediator;

        public SubcatagoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var response = await _mediator.Send(new AllSubcatagoriesQuery() { Page = page, Size = 10 });
            if (response.Succeeded)
                return View(response.SubCatagories);
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(null);
        }


        public async Task<IActionResult> Create()
        {
            CatagoryListQueryResponse response = await _mediator.Send(new CatagoryListQuery() 
            { Page = 1,Size = 10});
            if (response.Succeeded)
                return View(response.Catagories);
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatagoryDTO model, List<Guid> categoryIds)
        {
            CatagoryListQueryResponse catagories = await _mediator.Send(new CatagoryListQuery() 
            { Page = 1,Size= 10});

            CreateSubcatagoryCommandResponse response = await _mediator.Send(new CreateSubcatagoryCommand()
            { Subcatagory = model, CatagoryIds = categoryIds });
            if (response.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            if (catagories.Succeeded)
                return View(catagories.Catagories);
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            GetSubcatagoryByIdQueryResponse res = await _mediator.Send(new GetSubcatagoryByIdQuery()
            { Id = id });
            if (res.Succeeded)
                return View(res.SubCatagory);
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(res.SubCatagory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CatagoryDTO model, Guid id)
        {
            UpdateSubCatagoryCommandResponse res = await _mediator.Send(new UpdateSubCatagoryCommand() { Id = id, Subcatagory = model });
            if (res.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            DeleteSubcatagoryCommandResponse res = await _mediator.Send(new DeleteSubcatagoryCommand()
            { Id = id });
            return Json(new { success = res.Succeeded });
        }

    }
}
