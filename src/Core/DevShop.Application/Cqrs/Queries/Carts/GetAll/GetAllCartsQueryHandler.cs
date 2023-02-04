using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Carts.GetAll
{
    public class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQueryRequest, GetCartsQueryResponse>
    {
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _contextAccessor;
        public GetAllCartsQueryHandler(ICartService cartService, IHttpContextAccessor contextAccessor)
        {
            _cartService = cartService;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetCartsQueryResponse> Handle(GetAllCartsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            request.UserId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Cart> carts = await _cartService.GetCarts(request.UserId);
            if (carts.Count() == 0)
            {
                errorList.Add(new() { Description = "No products in cart" });
                return new() { Errors = errorList, Succeeded = false };
            }

            return new() { Succeeded = true, Carts = carts };
        }
    }
}
