using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetLastMessages(int count);
    }
}