using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using OT.Assessment.Core;
using OT.Assessment.Core.Entities;
using OT.Assessment.Tester.Infrastructure;
using Dapper;
namespace OT.Assessment.App.Model;

public readonly struct PlayerServices(
    OTDbContext dbContext, IOptions<PlayerOptions> options, ILogger<PlayerServices> logger)
{
public async Task<IEnumerable<CasinoWager>> GetPlayerCasinoWagersAsync(Guid playerId)
{
            string sql = @"sp_GetCasinoWagerByPlayerId";

            using IDbConnection connection = new Dapper.SqlConnection(AppConsts.GetConnectionString);

            int pageSize = paginationRequest.PageSize;
            int pageIndex = paginationRequest.PageIndex;

            var playerCasinoWagers = await connection.QueryAsync<CasinoWager>(sql, new { AccountId = playerId });
       public IOptions<PlayerOptions> Options { get; } = options;

    public ILogger<PlayerServices> Logger { get; } = logger;
    
};
