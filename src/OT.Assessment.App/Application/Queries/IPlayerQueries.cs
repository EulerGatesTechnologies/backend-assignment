using Microsoft.EntityFrameworkCore;
using OT.Assessment.Core.Entities;
using OT.Assessment.Tester.Infrastructure;

namespace OT.Assessment.App.Application.Queries
{
    public interface IPlayerQueries
    {
        Task<IEnumerable<CasinoWager>> GetPlayerCasinoWagersAsync(string playerId);
    }

    public class PlayerQueries : IPlayerQueries
    {

        public async Task<IEnumerable<CasinoWager>> GetPlayerCasinoWagersAsync(string playerId)
        {

            var casinoWagers = new List<CasinoWager>().AsQueryable();

            return await casinoWagers
                .ToListAsync();               
        }
    }
}