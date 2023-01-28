using AutoMapper;
using DevShop.Application.Cqrs.Commands.Catagories.AddCatagory;
using DevShop.Application.Cqrs.Commands.Catagories.DeleteCatagory;
using DevShop.Application.Cqrs.Commands.Catagories.UpdateCatagory;
using DevShop.Application.Cqrs.Queries.Catagories.CatagoryList;
using DevShop.Application.Cqrs.Queries.Catagories.GetCatagoryById;
using DevShop.Application.DTOs.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CatagoryController : Controller
    {
        private readonly IMediator _mediator;
        public CatagoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            CatagoryListQueryResponse response = await _mediator.Send(new CatagoryListQuery());
            if (response.Succeeded)
                return View(response.Catagories);
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatagoryDTO model)
        {
            bool result = await _mediator.Send(new AddCatagoryCommand() { Catagory = model });
            if (result)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", "An error occured");
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            GetCatagoryByIdQueryResponse response = await _mediator.Send(new GetCatagoryByIdQuery() { Id = id });
            if (response.Succeeded)
                return View(response.Catagory);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CatagoryDTO model)
        {
            UpdateCatagoryCommandResponse response = await _mediator.Send(new UpdateCatagoryCommand()
            { Catagory = model, Id = id });
            if (response.Succeeded)
                return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", "An error occured");
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteCatagoryCommandResponse response = await _mediator.Send(new DeleteCatagoryCommand()
            { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
