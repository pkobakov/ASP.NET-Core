using Microsoft.AspNetCore.Mvc;

namespace MyFirstWeb.Areas.Administration.Controllers
{
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
