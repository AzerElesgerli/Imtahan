using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImtahanBEEXAM.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        
    }
}