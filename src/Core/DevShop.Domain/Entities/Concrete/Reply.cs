using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Common;
using DevShop.Domain.Entities.Identity;

namespace DevShop.Domain.Entities.Concrete
{
    public class Reply:BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}