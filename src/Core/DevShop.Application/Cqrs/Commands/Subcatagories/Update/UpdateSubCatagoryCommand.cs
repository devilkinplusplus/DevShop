using DevShop.Application.DTOs.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Subcatagories.Update
{
    public class UpdateSubCatagoryCommand : IRequest<UpdateSubCatagoryCommandResponse>
    {
        public Guid Id { get; set; }
        public CatagoryDTO Subcatagory { get; set; }
    }
}
