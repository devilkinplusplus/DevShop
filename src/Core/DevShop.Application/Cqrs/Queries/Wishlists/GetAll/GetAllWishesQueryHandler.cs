using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Wishlists.GetAll
{
    public class GetAllWishesQueryHandler : IRequestHandler<GetAllWishesQueryRequest, GetAllWishesQueryResponse>
    {
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _contextAccessor;
        public GetAllWishesQueryHandler(IWishlistService wishlistService, IHttpContextAccessor contextAccessor)
        {
            _wishlistService = wishlistService;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllWishesQueryResponse> Handle(GetAllWishesQueryRequest request, CancellationToken cancellationToken)
        {
            request.UserId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Wishlist> results = await _wishlistService
                                .GetWishlists(request.UserId,request.Page,request.Size);
            if (results.Count() == 0)
                return new() { Succeeded = false };
            return new() { Succeeded = true, Wishlists = results };
        }
    }
}
