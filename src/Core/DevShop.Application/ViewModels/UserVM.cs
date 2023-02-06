using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.ViewModels
{
    public class UserVM
    {
        public AppUser User{ get; set; }
        public IEnumerable<Sale> Sales { get; set; }
    }
}
