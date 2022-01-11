using MyRecipes.Data.Common.Repositories;
using MyRecipes.Data.Models;
using MyRecipes.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRecipes.Services.Data
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IDeletableEntityRepository<Ingredient> ingredients;

        public IngredientsService(IDeletableEntityRepository<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public IEnumerable<T> GetAllPopular<T>()
        {
            return this.ingredients.All()
                .Where(x => x.Recipes.Count() >= 1)
                .To<T>()
                .ToList();
        }
    }
}
