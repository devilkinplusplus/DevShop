using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Subcatagories.GetAll
{
    public class AllSubcatagoriesResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<SubCatagory> SubCatagories { get; set; }
    }

}
