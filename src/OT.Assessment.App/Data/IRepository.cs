namespace OT.Assessment.App.Data;

public interface IRepository
{
    Task<PlayerAccount> GetPlayerAccountAsync(Guid id);
    Task<IEnumerable<PlayerCasinoWager>> GetPlayerCasinoWagersAsync(Guid playerId);
    Task AddPlayerCasinoWagerAsync(PlayerCasinoWager wager);
}
