namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;

    public class PagingViewModel
    {

        public int Page { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public bool HasNextPage => this.Page < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.RecipesCount / this.ItemsPerPage);

        public int PreviousPage => this.Page - 1;

        public int NextPage => this.Page + 1;

        public int RecipesCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}