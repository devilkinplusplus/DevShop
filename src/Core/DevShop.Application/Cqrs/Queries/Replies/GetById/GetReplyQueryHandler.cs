using DevShop.Application.Repositories.Replies;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Replies.GetById
{
    public class GetReplyQueryHandler : IRequestHandler<GetReplyQueryRequest, GetReplyQueryResponse>
    {
        private readonly IReplyReadRepository _replyReadRepository;

        public GetReplyQueryHandler(IReplyReadRepository replyReadRepository)
        {
            _replyReadRepository = replyReadRepository;
        }

        public async Task<GetReplyQueryResponse> Handle(GetReplyQueryRequest request, CancellationToken cancellationToken)
        {
            Reply data = await _replyReadRepository.GetAsync(x => x.Id == request.Id,"User","Contact");
            if (data is null)
            {
                List<IdentityError> errorList = new();
                errorList.Add(new() { Description = "Not found" });
                return new() { Succeeded = false, Errors = errorList };
            }
            return new() { Succeeded = true, Reply = data };
        }
    }
}
