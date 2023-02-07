using DevShop.Application.Repositories.Contacts;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Contacts.GetAll
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQueryRequest, GetAllContactsQueryResponse>
    {
        private readonly IContactReadRepository _contactRead;
        public GetAllContactsQueryHandler(IContactReadRepository contactRead)
        {
            _contactRead = contactRead;
        }

        public async Task<GetAllContactsQueryResponse> Handle(GetAllContactsQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Contact> contacts = await _contactRead
                            .GetAllAsync(x => x.IsDeleted == false, request.Page, request.Size);
            if (contacts.Count() == 0)
            {
                errorList.Add(new() { Description = "No contact message found" });
                return new() { Succeeded = false, Errors = errorList };
            }
            return new() { Succeeded = true, Contacts = contacts };
        }
    }
}
