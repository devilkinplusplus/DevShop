using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Contacts.GetById
{
    public class GetContactByIdQueryRequest:IRequest<GetContactByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
