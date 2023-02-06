using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Abstractions.Services;
using DevShop.Persistance.Context;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.ViewComponents.Catagories
{
    public class SubcatagoryListVC:ViewComponent
    {
        private readonly ISubcatagoryService _subcatagoryService;

        public SubcatagoryListVC(ISubcatagoryService subcatagoryService)
        {
            _subcatagoryService = subcatagoryService;
        }

        public IViewComponentResult Invoke(Guid id)
        {
            var catValues = _subcatagoryService.GetSubcatagoriesByCatagoryId(id);
            return View(catValues);
        }
    }
}