using DevShop.Application.Cqrs.Queries.Products.GetById;
using DevShop.Application.Cqrs.Queries.Products.NewProducts;
using DevShop.Application.Cqrs.Queries.Products.PopularProducts;
using DevShop.Application.Cqrs.Queries.Products.SimilarProducts;
using DevShop.Application.Cqrs.Queries.Subcatagories.GetAll;
using DevShop.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var subcatagories = await _mediator.Send(new AllSubcatagoriesQuery() { Page = 1, Size = 10 });
            var popularProducts = await _mediator.Send(new PopularProductsQueryRequest());
            var newProducts = await _mediator.Send(new NewProductsQueryRequest());
            HomeVM home = new()
            {
                SubCatagories = subcatagories.SubCatagories,
                PopularProducts = popularProducts.Products,
                NewProducts = newProducts.Products
            };

            return View(home);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            GetProductQueryResponse resp = await _mediator.Send(new GetProductQueryRequest() { Id = id });
            SimilarProductsQueryResponse res = await _mediator.Send(new SimilarProductsQueryRequest()
            { ProductId = id, SubCatagoryId = resp.Product.SubCatagoryId });
            DetailsVM details = new() { Product = resp.Product, SimilarProducts = res.Products };
            
            return View(details);
        }
    }
}
