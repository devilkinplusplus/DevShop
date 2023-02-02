using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.User.UserList
{
    public class UserListQuery : IRequest<UserListQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
