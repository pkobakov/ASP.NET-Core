namespace MyRecipes.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   public class IndexViewModel
    {
        public IEnumerable<IndexPageRecipeViewModel> RandomRecipes { get; set; }

        public int RecipesCount { get; set; }

        public int CategoriesCount { get; set; }

        public int IngredientsCount { get; set; }

        public int ImagesCount { get; set; }

    }
}
