using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Products.Create
{
    public class ProductCreateCommandRequest:IRequest<ProductCreateCommandResponse>
    {
        public Product Product { get; set; }
        public List<string> PictureIds { get; set; }
    }
}
