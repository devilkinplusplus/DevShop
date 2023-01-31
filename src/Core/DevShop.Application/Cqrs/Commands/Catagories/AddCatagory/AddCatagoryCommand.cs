using DevShop.Application.DTOs.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Catagories.AddCatagory
{
    public class AddCatagoryCommand:IRequest<AddCatagoryCommandResponse>
    {
        public CatagoryDTO Catagory { get; set; }
    }
}
