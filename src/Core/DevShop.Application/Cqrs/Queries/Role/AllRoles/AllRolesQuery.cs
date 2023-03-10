using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Role.AllRoles
{
    public class AllRolesQuery:IRequest<AllRolesQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
