using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Catagory;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services
{
    public class CatagoryService : ICatagoryService
    {
        private readonly AppDbContext _context;
        public CatagoryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Catagory> GetActiveCatagories()
        {
            return _context.Catagory.Include(x=>x.CatagorySubs).Where(x=>x.IsDeleted ==false).ToList();
        }
    }
}
