namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRecipes.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel model, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int id, int itemsPerPage = 4);

        int GetCount();

        T GetById<T>(int id);
    }
}
