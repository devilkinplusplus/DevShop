using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Wishlists.GetAll
{
    public class GetAllWishesQueryRequest:IRequest<GetAllWishesQueryResponse>
    {
        public string UserId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
