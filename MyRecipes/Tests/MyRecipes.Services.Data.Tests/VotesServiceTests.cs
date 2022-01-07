namespace MyRecipes.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task WhenUserVotesTwoTimesOnlyOneWillBeCounted()
        {
            var repo = new FakeVotesRepository();
            var service = new VotesService(repo);
            await service.SetVoteAsync(1, "1", 1);
            await service.SetVoteAsync(1, "1", 5);

            Assert.Equal(1, repo.All().Count());
        }
    }

    public class FakeVotesRepository : IRepository<Vote>
    {
        private List<Vote> list = new List<Vote>();

        public Task AddAsync(Vote entity)
        {
            this.list.Add(entity);
            return Task.CompletedTask;
        }

        public IQueryable<Vote> All()
        {
            return this.list.AsQueryable();
        }

        public IQueryable<Vote> AllAsNoTracking()
        {
            return this.list.AsQueryable();
        }

        public void Delete(Vote entity)
        {
        }

        public void Dispose()
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return null;
        }

        public void Update(Vote entity)
        {
        }
    }
}
