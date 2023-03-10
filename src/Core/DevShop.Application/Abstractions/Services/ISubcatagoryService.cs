using DevShop.Application.ViewModels;
using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services
{
    public interface ISubcatagoryService
    {
        //no asynchronous for calling in viewcomponent
        IEnumerable<SubCatagory> GetSubcatagoriesByCatagoryId(Guid catagoryId);
    }
}
