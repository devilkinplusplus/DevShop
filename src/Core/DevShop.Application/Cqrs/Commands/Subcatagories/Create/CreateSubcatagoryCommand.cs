using DevShop.Application.DTOs.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Subcatagories.Create
{
    public class CreateSubcatagoryCommand:IRequest<CreateSubcatagoryCommandResponse>
    {
        public CatagoryDTO Subcatagory { get; set; }
        public List<Guid> CatagoryIds { get; set; }
    }
}
