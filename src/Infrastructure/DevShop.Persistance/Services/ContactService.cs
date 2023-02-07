using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Abstractions.Services;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DevShop.Persistance.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetLastMessages(int count)
        {
            return _context.Contact.Where(x=>x.IsDeleted == false).OrderByDescending(x=>x.Date)
                                                                    .Take(count).ToList();
        }
    }
}