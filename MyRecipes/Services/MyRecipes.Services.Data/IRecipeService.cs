namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRecipes.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel model, string userId);

        IEnumerable<RecipeInListViewModel> GetAll(int id, int itemsPerPage = 4);

        int GetCount();
    }
}
