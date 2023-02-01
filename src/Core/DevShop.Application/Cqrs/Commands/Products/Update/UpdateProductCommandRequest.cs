using DevShop.Application.DTOs.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Products.Update
{
    public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public ProductDTO ProductDto { get; set; }
    }
}
