using Microsoft.EntityFrameworkCore;

namespace OT.Assessment.Data;

public class OnlineBettingDbContext : DbContext
{
    public OnlineBettingDbContext(DbContextOptions<OnlineBettingDbContext> options)
    : base(options)
    {
    }

    public DbSet<PlayerAccount> PlayerAccounts { get; set; }
    public DbSet<PlayerCasinoWager> PlayerCasinoWagers { get; set; }
}
