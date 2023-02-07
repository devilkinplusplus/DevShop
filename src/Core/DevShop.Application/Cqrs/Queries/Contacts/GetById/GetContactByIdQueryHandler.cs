using DevShop.Application.Repositories.Contacts;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Contacts.GetById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQueryRequest, GetContactByIdQueryResponse>
    {
        private readonly IContactReadRepository _contactRead;

        public GetContactByIdQueryHandler(IContactReadRepository contactRead)
        {
            _contactRead = contactRead;
        }

        public async Task<GetContactByIdQueryResponse> Handle(GetContactByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Contact data = await _contactRead.GetAsync(x => x.Id == request.Id);
            if(data is null)
            {
                List<IdentityError> errorList = new();
                errorList.Add(new() { Description = "Not found" });
                return new() { Succeeded = false, Errors = errorList };
            }
            return new() { Succeeded = true, Contact = data };
        }
    }
}
