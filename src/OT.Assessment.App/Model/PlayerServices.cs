using Microsoft.Extensions.Options;

namespace OT.Assessment.App.Model;

public readonly struct PlayerServices(IDbContext dbContext, IOptions<PlayerOptions> options, ILogger<PlayerServices> logger)
{
    public IDbContext DbContext { get; } = dbContext;

    public IOptions<PlayerOptions> Options { get; } = options;

    public ILogger<PlayerServices> Logger { get; } = logger;
    
};

public interface IDbContext
{
}