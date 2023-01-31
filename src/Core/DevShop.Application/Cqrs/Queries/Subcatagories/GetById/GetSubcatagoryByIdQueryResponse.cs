using DevShop.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Subcatagories.GetById
{
    public class GetSubcatagoryByIdQueryResponse
    {
        public bool Succeeded { get; set; }
        public SubCatagory SubCatagory { get; set; }
        public List<IdentityError> Errors { get; set; }

    }
}
