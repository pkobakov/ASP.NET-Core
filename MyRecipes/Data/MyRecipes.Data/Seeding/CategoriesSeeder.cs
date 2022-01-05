namespace MyRecipes.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyRecipes.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Основни ястия" });
            await dbContext.Categories.AddAsync(new Category { Name = "Супи" });
            await dbContext.Categories.AddAsync(new Category { Name = "Пици" });
            await dbContext.Categories.AddAsync(new Category { Name = "Десерти" });
            await dbContext.Categories.AddAsync(new Category { Name = "Салати" });
            await dbContext.Categories.AddAsync(new Category { Name = "Паста и ризото" });
            await dbContext.Categories.AddAsync(new Category { Name = "Предястия" });



            await dbContext.SaveChangesAsync();
        }
    }
}
