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

        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new AllSubcatagoriesQuery());
            if (response.Succeeded)
                return View(response.SubCatagories);
            ModelState.AddModelError("", "No item found!");
            return View(null);
        }


        public async Task<IActionResult> Create()
        {
            CatagoryListQueryResponse response = await _mediator.Send(new CatagoryListQuery());
            if (response.Succeeded)
                return View(response.Catagories);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatagoryDTO model, List<Guid> categoryIds)
        {
            CreateSubcatagoryCommandResponse response = await _mediator.Send(new CreateSubcatagoryCommand()
            { Subcatagory = model, CatagoryIds = categoryIds });
            if (response.Succeeded)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", "An error occured");
            return RedirectToAction(nameof(Create));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            GetSubcatagoryByIdQueryResponse res = await _mediator.Send(new GetSubcatagoryByIdQuery() { Id = id });
            if (res.Succeeded)
                return View(res.SubCatagory);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CatagoryDTO model, Guid id)
        {
            UpdateSubCatagoryCommandResponse res = await _mediator.Send(new UpdateSubCatagoryCommand() { Id = id, Subcatagory = model });
            if (res.Succeeded)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", "An error occured");
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteSubcatagoryCommand() { Id = id });
            return RedirectToAction(nameof(Index));
        }

    }
}
