namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipeService : IRecipeService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public RecipeService(IDeletableEntityRepository<Recipe> recipesRepository, IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.recipesRepository = recipesRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public async Task CreateAsync(CreateRecipeInputModel model, string userId)
        {
           var recipe = new Recipe
           {
            Name = model.Name,
            CookingTime = TimeSpan.FromMinutes(model.CookingTime),
            PreparationTime = TimeSpan.FromMinutes(model.PreparationTime),
            Instructions = model.Instructions,
            PortionsCount = model.PortionsCount,
            CategoryId = model.CategoryId,
            AddedByUserId = userId,
           };

           foreach (var inputIngredient in model.Ingredients)
           {
                var ingredient = this.ingredientRepository.All().FirstOrDefault(x => x.Name == inputIngredient.Name);

                if (ingredient == null)
                {
                    ingredient = new Ingredient { Name = inputIngredient.Name };
                }

                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = inputIngredient.Quantity,
                });

                await this.recipesRepository.AddAsync(recipe);
                await this.recipesRepository.SaveChangesAsync();
           }
        }

        public IEnumerable<RecipeInListViewModel> GetAll(int page, int itemsPerPage = 4)
        {
            var recipes = this.recipesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<RecipeInListViewModel>()
                .ToList();
            return recipes;
        }

        public int GetCount()
        {
            return this.recipesRepository.All().Count();
        }
    }
}
