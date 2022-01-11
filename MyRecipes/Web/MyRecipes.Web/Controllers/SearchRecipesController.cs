namespace MyRecipes.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;
    using MyRecipes.Web.ViewModels.SearchRecipes;

    public class SearchRecipesController : BaseController
    {
        private readonly IRecipeService recipesService;
        private readonly IIngredientsService ingredientService;

        public SearchRecipesController(
            IRecipeService recipesService,
            IIngredientsService ingredientService)
        {
            this.recipesService = recipesService;
            this.ingredientService = ingredientService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Ingredients = this.ingredientService.GetAllPopular<IngredientNameIdViewModel>(),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel model)
        {
            var viewModel = new ListViewModel()
            {
                Recipes = this.recipesService
                .GetByIngredients<RecipeInListViewModel>(model.Ingredients),
            };

            return this.View(viewModel);
        }
    }
}
