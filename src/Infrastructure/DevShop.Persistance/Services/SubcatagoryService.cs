using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Catagory;
using DevShop.Application.Repositories.Catagorysub;
using DevShop.Application.Repositories.Subcatagory;
using DevShop.Application.ViewModels;
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
    public class SubcatagoryService : ISubcatagoryService
    {
        private readonly AppDbContext _context;
        public SubcatagoryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SubCatagory> GetSubcatagoriesByCatagoryId(Guid catagoryId)
        {
            return _context.CatagorySub.Include(x=>x.Catagory).Include(x=>x.SubCatagory)
                                  .Where(x=>x.CatagoryId == catagoryId && x.IsDeleted == false).Select(x=>x.SubCatagory).ToList();
        }
    }
}
