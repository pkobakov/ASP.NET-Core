namespace MyRecipes.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Votes;

    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;

        public VotesController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<PostVoteResponseModel>> Post(VotesPostModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.votesService.SetVoteAsync(model.RecipeiId, userId, model.Value);
            var averageVotes = this.votesService.GetAverageVote(model.RecipeiId);
            return new PostVoteResponseModel { AverageVote = averageVotes };
        }
    }
}
