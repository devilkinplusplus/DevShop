using DevShop.Application.Repositories.Wishlists;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Wishlists.Delete
{
    public class DeleteWishCommandHandler : IRequestHandler<DeleteWishCommandRequest, DeleteWishCommandResponse>
    {
        private readonly IWishlistReadRepository _wishReadRepository;
        private readonly IWishlistWriteRepository _wishWriteRepository;
        public DeleteWishCommandHandler(IWishlistReadRepository wishReadRepository, IWishlistWriteRepository wishWriteRepository)
        {
            _wishReadRepository = wishReadRepository;
            _wishWriteRepository = wishWriteRepository;
        }

        public async Task<DeleteWishCommandResponse> Handle(DeleteWishCommandRequest request, CancellationToken cancellationToken)
        {
            Wishlist data = await _wishReadRepository.GetByIdAsync(request.Id);
            if (data is null)
                return new() { Succeeded = false };
            data.IsDeleted = true;
            await _wishWriteRepository.UpdateAsync(data);
            return new() { Succeeded = true };
        }
    }
}
