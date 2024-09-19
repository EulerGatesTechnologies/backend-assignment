namespace OT.Assessment.App.Data;

public class OnlineBettingDbContext : IDbContext
{
    public OnlineBettingDbContext(IDbContextOptions<OnlineBettingDbContext> options) 
    : base(options)
    {
    }

    public DbSet<PlayerAccount> PlayerAccounts { get; set; }
    public DbSet<PlayerCasinoWager> PlayerCasinoWagers { get; set; }
}
