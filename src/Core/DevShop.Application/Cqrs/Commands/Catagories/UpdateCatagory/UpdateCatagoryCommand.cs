using DevShop.Application.DTOs.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Catagories.UpdateCatagory
{
    public class UpdateCatagoryCommand:IRequest<UpdateCatagoryCommandResponse>
    {
        public Guid Id { get; set; }
        public CatagoryDTO Catagory { get; set; }
    }
}
