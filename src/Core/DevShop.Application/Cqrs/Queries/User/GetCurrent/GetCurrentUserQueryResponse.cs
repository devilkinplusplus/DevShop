using DevShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.User.GetCurrent
{
    public class GetCurrentUserQueryResponse
    {
        public AppUser AppUser { get; set; }
    }
}
