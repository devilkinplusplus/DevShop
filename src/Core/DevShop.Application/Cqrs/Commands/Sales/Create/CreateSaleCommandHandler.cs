using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Sales.Create
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommandRequest, CreateSaleCommandResponse>
    {
        private readonly ISaleService _saleService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;
        public CreateSaleCommandHandler(ISaleService saleService, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IProductService productService)
        {
            _saleService = saleService;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _productService = productService;
        }

        public async Task<CreateSaleCommandResponse> Handle(CreateSaleCommandRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = await _userManager.FindByIdAsync(userId);

            float totalPriceOfProducts = request.TotalAmount;

            if (!(user.Budget >= totalPriceOfProducts))
            {
                errorList.Add(new() { Description = "Insufficient Balance" });
                return new() { Errors = errorList, Succeeded = false };
            }
            var datas = await _productService.GetPaymentFromSales(request.ProductId);
            user.Budget -= totalPriceOfProducts;
            await _userManager.UpdateAsync(user);
            for (int i = 0; i < datas.ProductIds.Count; i++)
            {
                await _saleService.CreateSales(datas.ProductIds[i], userId, datas.SellerIds[i]);
            }
            
            return new() { Succeeded = true };

        }
    }
}
