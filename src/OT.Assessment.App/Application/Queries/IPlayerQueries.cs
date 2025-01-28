using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Infrastructure;
using OT.Assessment.Core.Entities;

namespace OT.Assessment.App.Application.Queries
{
    public interface IPlayerQueries
    {
        Task<IEnumerable<PlayerCasinoWager>> GetPlayerCasinoWagersAsync(string playerId);
    }

    public class PlayerQueries : IPlayerQueries
    {
        private OtAssessmentDbContext _dbContext;

        public PlayerQueries()
        {
        }

        public PlayerQueries(OtAssessmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PlayerCasinoWager>> GetPlayerCasinoWagersAsync(string playerId)
        {
            return await _dbContext.PlayerCasinoWagers.Where(pcw => pcw.PlayerId.ToString().Equals(playerId)).ToListAsync();

        }
    }
}