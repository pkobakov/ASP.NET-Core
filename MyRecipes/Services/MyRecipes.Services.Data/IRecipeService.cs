namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyRecipes.Data.Models;
    using MyRecipes.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel model, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int id, int itemsPerPage = 4);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);
    }
}
