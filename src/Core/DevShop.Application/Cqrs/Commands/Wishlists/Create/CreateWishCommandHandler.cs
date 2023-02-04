using DevShop.Application.Repositories.Carts;
using DevShop.Application.Repositories.Wishlists;
using DevShop.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Wishlists.Create
{
    public class CreateWishCommandHandler : IRequestHandler<CreateWishCommandRequest, CreateWishCommandResponse>
    {
        private readonly IWishlistWriteRepository _wishlistWrite;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWishlistReadRepository _wishlistRead;
        public CreateWishCommandHandler(IWishlistWriteRepository wishlistWrite, IHttpContextAccessor contextAccessor, IWishlistReadRepository wishlistRead)
        {
            _wishlistWrite = wishlistWrite;
            _contextAccessor = contextAccessor;
            _wishlistRead = wishlistRead;
        }

        public async Task<CreateWishCommandResponse> Handle(CreateWishCommandRequest request, CancellationToken cancellationToken)
        {
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await _wishlistRead
                       .GetAsync(x => x.UserId == userId && x.ProductId == request.Wishlist.ProductId && x.IsDeleted == false);
            if (data is not null)
                return new() { Succeeded = false };

            request.Wishlist.UserId = userId;
            await _wishlistWrite.AddAsync(request.Wishlist);
            return new() { Succeeded = true };
        }
    }
}
