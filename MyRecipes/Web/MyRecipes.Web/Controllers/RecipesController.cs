using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Data;
using MyRecipes.Web.ViewModels.Recipes;

namespace MyRecipes.Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public RecipesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllKeyValuePairs() ;
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
                return this.View(model);
            }

            return this.Redirect("/");

        }
    }
}
