using System.Diagnostics;
using DevShop.Application.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.Controllers
{
    public class ErrorController : Controller
    {
       
        public IActionResult NotFound(){
            return View();
        }


    }
}
