using DevShop.Application.Repositories.Pictures;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Repositories.Pictures
{
    public class PictureWriteRepository : WriteRepository<Picture>, IPictureWriteRepository
    {
        public PictureWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
