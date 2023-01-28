using AutoMapper;
using DevShop.Application.Cqrs.Commands.Catagories.AddCatagory;
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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCatagoryDTO model)
        {
            bool result = await _mediator.Send(new AddCatagoryCommand() { Catagory = model });
            if (result)
                return RedirectToAction(nameof(Index));
            return View();
        }
    }
}
