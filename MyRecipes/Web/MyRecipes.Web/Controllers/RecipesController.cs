using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Data;
using MyRecipes.Web.ViewModels.Recipes;
using System.Threading.Tasks;

namespace MyRecipes.Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipeService recipeService;

        public RecipesController(ICategoriesService categoriesService, IRecipeService recipeService)
        {
            this.categoriesService = categoriesService;
            this.recipeService = recipeService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
                return this.View(model);
            }

            await this.recipeService.CreateAsync(model);
            return this.Redirect("/");

        }
    }
}
