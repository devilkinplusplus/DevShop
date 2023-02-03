using DevShop.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Products.IncreaseView
{
    public class IncreaseViewCommandHandler : IRequestHandler<IncreaseViewCommandRequest, IncreaseViewCommandResponse>
    {
        private readonly IProductService _productService;

        public IncreaseViewCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IncreaseViewCommandResponse> Handle(IncreaseViewCommandRequest request, CancellationToken cancellationToken)
        {
            return new() { Succeeded = await _productService.IncreaseView(request.ProductId) };
        }
    }
}
