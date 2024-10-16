using Microsoft.EntityFrameworkCore;

namespace OT.Assessment.Data;

public class OnlineBettingDbContext(DbContextOptions<OnlineBettingDbContext> options) : DbContext(options)
{
    public DbSet<PlayerAccount> PlayerAccounts { get; set; }
    public DbSet<PlayerCasinoWager> PlayerCasinoWagers { get; set; }
}
