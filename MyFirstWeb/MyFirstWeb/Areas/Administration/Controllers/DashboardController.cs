using Microsoft.AspNetCore.Mvc;

namespace MyFirstWeb.Areas.Administration.Controllers
{
    [Area("Administration") ]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
