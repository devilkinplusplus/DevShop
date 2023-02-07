using DevShop.Application.Repositories.Replies;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Replies.GetAll
{
    public class GetAllRepliesQueryHandler : IRequestHandler<GetAllRepliesQueryRequest, GetAllRepliesQueryResponse>
    {
        private readonly IReplyReadRepository _replyRead;

        public GetAllRepliesQueryHandler(IReplyReadRepository replyRead)
        {
            _replyRead = replyRead;
        }

        public async Task<GetAllRepliesQueryResponse> Handle(GetAllRepliesQueryRequest request, CancellationToken cancellationToken)
        {
            List<IdentityError> errorList = new();
            IEnumerable<Reply> results = await _replyRead
                    .GetAllAsync(x => x.IsDeleted == false, request.Page, request.Size,"User","Contact");

            if(results.Count() == 0)
            {
                errorList.Add(new() { Description = "No replies found" });
                return new() { Succeeded = false, Errors = errorList };
            }

            return new() { Succeeded = true, Replies = results};
        }
    }
}
