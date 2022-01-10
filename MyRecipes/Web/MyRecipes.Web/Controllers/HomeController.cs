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
        private readonly IRecipeService recipeService;

        public HomeController(
            IGetCountsService getCountsService,
            IRecipeService recipeService)
        {
            this.getCountsService = getCountsService;
            this.recipeService = recipeService;
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
                RandomRecipes = this.recipeService.GetRandom<IndexPageRecipeViewModel>(8),
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
