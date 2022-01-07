namespace MyRecipes.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVote(int recipeId)
        {
            return this.votesRepository.All()
                .Where(v => v.RecipeId == recipeId)
                .Average(v => v.Value);
        }

        public async Task SetVoteAsync(int recipeId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                      .FirstOrDefault(v => v.UserId == userId && v.RecipeId == recipeId);
            if (vote == null)
            {
                vote = new Vote
                {
                    RecipeId = recipeId,
                    UserId = userId,
                };
                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
