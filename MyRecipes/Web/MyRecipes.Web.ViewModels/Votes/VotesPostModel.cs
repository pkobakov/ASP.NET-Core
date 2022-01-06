namespace MyRecipes.Web.ViewModels.Votes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VotesPostModel
    {
        public int RecipeiId { get; set; }

        [Range(1,5)]
        public byte Value { get; set; }
    }
}
