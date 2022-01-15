using Microsoft.AspNetCore.Mvc;

namespace ChatWithSignalR.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

      

    }
}
