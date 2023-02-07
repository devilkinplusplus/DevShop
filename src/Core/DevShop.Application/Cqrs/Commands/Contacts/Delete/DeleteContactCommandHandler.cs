using DevShop.Application.Repositories.Contacts;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Contacts.Delete
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommandRequest, DeleteContactCommandResponse>
    {
        private readonly IContactReadRepository _contactRead;
        private readonly IContactWriteRepository _contactWrite;
        public DeleteContactCommandHandler(IContactReadRepository contactRead, IContactWriteRepository contactWrite)
        {
            _contactRead = contactRead;
            _contactWrite = contactWrite;
        }

        public async Task<DeleteContactCommandResponse> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
        {
            Contact data = await _contactRead.GetByIdAsync(request.Id);
            data.IsDeleted = true;
            await _contactWrite.UpdateAsync(data);
            return new() { Succeeded = true };
        }
    }
}
