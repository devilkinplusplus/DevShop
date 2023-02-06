using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Repositories.Contacts;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;

namespace DevShop.Persistance.Repositories.Contacts
{
    public class ContactWriteRepository : WriteRepository<Contact>, IContactWriteRepository
    {
        public ContactWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}