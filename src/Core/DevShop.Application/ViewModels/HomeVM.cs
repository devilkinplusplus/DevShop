using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<SubCatagory> SubCatagories { get; set; }
        public IEnumerable<Product> PopularProducts { get; set; }
        public IEnumerable<Product> NewProducts { get; set; }

    }
}
