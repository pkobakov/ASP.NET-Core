namespace MyRecipes.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Home;

    // 1. ApplicationDbcontext
    // 2. Repositories
    // 3. Service
    public class HomeController : BaseController
    {
        private readonly IGetCountsService getCountsService;

        public HomeController(IGetCountsService getCountsService)
        {
            this.getCountsService = getCountsService;
        }

        public IActionResult Index()
        {
            var counts = this.getCountsService.GetCounts();

            var viewModel = new IndexViewModel
            {
                CategoriesCount = counts.CategoriesCount,
                RecipesCount = counts.RecipesCount,
                ImagesCount = counts.ImagesCount,
                IngredientsCount = counts.IngredientsCount,
            };

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
                new ViewModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
