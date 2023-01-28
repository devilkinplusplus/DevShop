using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Catagories.GetCatagoryById
{
    public class GetCatagoryByIdQueryResponse
    {
        public Catagory Catagory { get; set; }
        public bool Succeeded { get; set; }
    }
}
