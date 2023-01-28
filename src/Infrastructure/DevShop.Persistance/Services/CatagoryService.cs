using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Catagory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services
{
    public class CatagoryService:ICatagoryService
    {
        private readonly ICatagoryReadRepository _catagoryReadRepository;
        private readonly ICatagoryWriteRepository _catagoryWriteRepository;
        public CatagoryService(ICatagoryReadRepository catagoryReadRepository, ICatagoryWriteRepository catagoryWriteRepository)
        {
            _catagoryReadRepository = catagoryReadRepository;
            _catagoryWriteRepository = catagoryWriteRepository;
        }

    }
}
