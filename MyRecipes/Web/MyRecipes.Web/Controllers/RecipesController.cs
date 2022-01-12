namespace MyRecipes.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Common;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipeService recipeService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipeService recipeService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.recipeService = recipeService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
                return this.View(model);
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.recipeService.CreateAsync(model, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                model.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
                return this.View(model);
            }

            this.TempData["Message"] = "Recipe added successfully";

            return this.RedirectToAction("All");
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 4;

            var viewModel = new RecipesListViewModel
            {
                ItemsPerPage = itemsPerPage,
                Page = id,
                Recipes = this.recipeService.GetAll<RecipeInListViewModel>(id, itemsPerPage),
                RecipesCount = this.recipeService.GetCount(),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var recipe = this.recipeService.GetById<SingleRecipeViewModel>(id);
            return this.View(recipe);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.recipeService.GetById<EditRecipeInputModel>(id);
            inputModel.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditRecipeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
                return this.View(model);
            }

            model.CategoriesItems = this.categoriesService.GetAllKeyValuePairs();
            await this.recipeService.UpdateAsync(id, model);

            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.recipeService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
