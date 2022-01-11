namespace MyRecipes.Web.ViewModels.SearchRecipes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SearchIndexViewModel
    {
        public IEnumerable<IngredientNameIdViewModel> Ingredients { get; set; }
    }
}
