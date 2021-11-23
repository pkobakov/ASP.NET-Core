namespace MyRecipes.Services.Data
{
    using MyRecipes.Services.Data.Models;
    using MyRecipes.Web.ViewModels.Home;

    public interface IGetCountsService
    {
        // 1. Use View Model
        CountsDto GetCounts();
    }
}
