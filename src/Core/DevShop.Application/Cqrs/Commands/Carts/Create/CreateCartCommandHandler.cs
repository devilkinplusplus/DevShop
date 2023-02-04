using DevShop.Application.Repositories.Carts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Carts.Create
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommandRequest, CreateCartCommandResponse>
    {
        private readonly ICartWriteRepository _cartWriteRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICartReadRepository _cartReadRepository;
        public CreateCartCommandHandler(ICartWriteRepository cartWriteRepository, IHttpContextAccessor httpContextAccessor, ICartReadRepository cartReadRepository)
        {
            _cartWriteRepository = cartWriteRepository;
            _httpContextAccessor = httpContextAccessor;
            _cartReadRepository = cartReadRepository;
        }

        public async Task<CreateCartCommandResponse> Handle(CreateCartCommandRequest request, CancellationToken cancellationToken)
        {
            var userId= _httpContextAccessor.HttpContext.User
                                  .FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await _cartReadRepository
                        .GetAsync(x => x.UserId == userId && x.ProductId == request.Cart.ProductId && x.IsDeleted == false);

            if(data is not null)
            {
                return new() {  Succeeded = false };
            }

            request.Cart.UserId = userId;
            await _cartWriteRepository.AddAsync(request.Cart);
            return new() { Succeeded = true };
        }
    }
}
