using DevShop.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Catagories.CatagoryList
{
    public class CatagoryListQueryResponse
    {
        public IEnumerable<Catagory> Catagories { get; set; }
        public List<IdentityError> Errors { get; set; }
        public bool Succeeded { get; set; }
    }
}
