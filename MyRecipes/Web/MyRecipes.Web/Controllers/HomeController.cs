namespace MyRecipes.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Data;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels;
    using MyRecipes.Web.ViewModels.Home;

    // 1. ApplicationDbcontext
    // 2. Repositories
    // 3. Service
    public class HomeController : BaseController
    {
        private readonly IGetCountsService getCountsService;

        public HomeController(IGetCountsService getCountsService )
        {
            this.getCountsService = getCountsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.getCountsService.GetCounts();

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
