using DevShop.Application.Repositories.Replies;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Replies.Delete
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteReplyCommandRequest, DeleteReplyCommandResponse>
    {
        private readonly IReplyReadRepository _replyRead;
        private readonly IReplyWriteRepository _replyWrite;
        public DeleteContactCommandHandler(IReplyReadRepository replyRead, IReplyWriteRepository replyWrite)
        {
            _replyRead = replyRead;
            _replyWrite = replyWrite;
        }

        public async Task<DeleteReplyCommandResponse> Handle(DeleteReplyCommandRequest request, CancellationToken cancellationToken)
        {
            Reply reply = await _replyRead.GetByIdAsync(request.Id);
            reply.IsDeleted = true;
            await _replyWrite.UpdateAsync(reply);
            return new() { Succeeded = true };
        }
    }
}
