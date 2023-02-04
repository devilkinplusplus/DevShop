using DevShop.Application.Repositories.Carts;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Carts.Delete
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommandRequest, DeleteCartCommandResponse>
    {
        private readonly ICartReadRepository _cartReadRepo;
        private readonly ICartWriteRepository _cartWriteRepo;
        public DeleteCartCommandHandler(ICartReadRepository cartReadRepo, ICartWriteRepository cartWriteRepo)
        {
            _cartReadRepo = cartReadRepo;
            _cartWriteRepo = cartWriteRepo;
        }

        public async Task<DeleteCartCommandResponse> Handle(DeleteCartCommandRequest request, CancellationToken cancellationToken)
        {
            Cart data = await _cartReadRepo.GetByIdAsync(request.Id);
            if (data is null)
                return new() { Succeeded = false };
            data.IsDeleted = true;
            await _cartWriteRepo.UpdateAsync(data);
            return new() { Succeeded = true };
        }
    }
}
