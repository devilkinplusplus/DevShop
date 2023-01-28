using DevShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Entities.Concrete
{
    public class Catagory:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CatagorySub> CatagorySubs { get; set; }
    }
}
