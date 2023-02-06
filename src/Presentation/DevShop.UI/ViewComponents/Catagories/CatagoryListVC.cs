using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.ViewComponents.Catagories
{
    public class CatagoryListVC:ViewComponent
    {
        private readonly ICatagoryService _catagoryService;
        public CatagoryListVC(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public IViewComponentResult Invoke()
        {
            var catValues = _catagoryService.GetActiveCatagories();
            return View(catValues);
        }
    }
}