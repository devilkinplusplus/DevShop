using DevShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Domain.Entities.Concrete
{
    public class CatagorySub:BaseEntity
    {
        public Guid CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
        public Guid SubCatagoryId { get; set; }
        public SubCatagory SubCatagory { get; set; }
    }
}
