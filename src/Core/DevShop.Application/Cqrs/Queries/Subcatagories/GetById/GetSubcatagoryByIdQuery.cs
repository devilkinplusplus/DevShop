using DevShop.Application.DTOs.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Subcatagories.GetById
{
    public class GetSubcatagoryByIdQuery:IRequest<GetSubcatagoryByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
