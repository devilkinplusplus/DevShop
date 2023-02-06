using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevShop.Domain.Entities.Concrete;

namespace DevShop.Application.Abstractions.Services
{
    public interface ICatagoryService
    {
        //non async method for view component 
        IEnumerable<Catagory> GetActiveCatagories();
    }
}
