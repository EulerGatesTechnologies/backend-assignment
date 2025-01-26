using Microsoft.EntityFrameworkCore;
using OT.Assessment.Core.Entities;

namespace OT.Assessment.App.Application.Queries
{
    public class OrderingContext : DbContext
    {
        public DbSet<PlayerCasinoWager> PlayerCasinoWagers { get; set; }
    }
}