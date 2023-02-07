using DevShop.Application.Repositories.Contacts;
using DevShop.Application.Validations;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Contacts.Create
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse>
    {
        private readonly IContactWriteRepository _contactWrite;

        public CreateContactCommandHandler(IContactWriteRepository contactWrite)
        {
            _contactWrite = contactWrite;
        }

        public async Task<CreateContactCommandResponse> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            ContactValidator validations = new();
            request.Contact.Date = DateTime.Now;
            ValidationResult results = validations.Validate(request.Contact);

            if (results.IsValid)
            {
                await _contactWrite.AddAsync(request.Contact);
                return new() { Succeeded = true };
            }

            return new() { Succeeded = false, Errors = results.Errors };
        }
    }
}
