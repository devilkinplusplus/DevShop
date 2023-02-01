using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.ViewModels
{
    public class EditProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SubCatagory> SubCatagories { get; set; }
    }
}
