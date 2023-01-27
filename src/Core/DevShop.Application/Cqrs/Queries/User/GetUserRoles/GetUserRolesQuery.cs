using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.User.GetUserRoles
{
    public class GetUserRolesQuery:IRequest<GetUserRolesQueryResponse>
    {
        public string Id { get; set; }
    }
}
