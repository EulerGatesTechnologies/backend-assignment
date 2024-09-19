namespace OT.Assessment.App.Data;

public class Repository : IRepository
{
    private readonly OnlineBettingDbContext _context;

    public Repository(OnlineBettingDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerAccount> GetPlayerAccountAsync(Guid id)
    {
        return await _context.PlayerAccounts.FindAsync(id);
    }

    public async Task<IEnumerable<PlayerCasinoWager>> GetPlayerCasinoWagersAsync(Guid playerId)
    {
        return await _context.PlayerCasinoWagers.Where(w => w.PlayerAccountId == playerId).ToListAsync();
    }

    public async Task AddPlayerCasinoWagerAsync(PlayerCasinoWager wager)
    {
        _context.PlayerCasinoWagers.Add(wager);
        await _context.SaveChangesAsync();
    }
}
