namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task SetVoteAsync(int recipeId, string userId, byte value);

        double GetAverageVote(int recipeId);
    }
}
