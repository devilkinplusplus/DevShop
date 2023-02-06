using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Common;

namespace DevShop.Domain.Entities.Concrete
{
    public class Contact:BaseEntity
    {
        public string? Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}