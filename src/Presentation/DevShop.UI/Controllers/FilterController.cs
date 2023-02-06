using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevShop.UI.Controllers
{
    public class FilterController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> FilterPrice(string[] prices){
            float[] values = Array.ConvertAll(prices, s => float.Parse(s.TrimStart('$')));

            return Json(values);
        }
    }
}