using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Catagories.GetCatagoryById
{
    public class GetCatagoryByIdQuery:IRequest<GetCatagoryByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
