namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyRecipes.Data.Models;
    using MyRecipes.Web.ViewModels.Recipes;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel model, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int id, int itemsPerPage = 4);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync (int id, EditRecipeInputModel model);

        Task DeleteAsync(int id);

        IEnumerable<T> GetByIngredients<T>(IEnumerable<int> ingredientsIds);
    }
}
