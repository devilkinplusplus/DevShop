using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Concrete;

namespace DevShop.Application.Repositories.Contacts
{
    public interface IContactWriteRepository:IWriteRepository<Contact>
    {
    }
}