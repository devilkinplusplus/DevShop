using DevShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.User.UserList
{
    public class UserListQueryResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<AppUser> Users { get; set; }
        public List<IdentityError> Errors { get; set; }
    }
}
