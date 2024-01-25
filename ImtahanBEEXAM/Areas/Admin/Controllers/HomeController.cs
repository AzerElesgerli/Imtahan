using Microsoft.AspNetCore.Mvc;

namespace ImtahanBEEXAM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
