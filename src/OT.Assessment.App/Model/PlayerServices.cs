using Microsoft.Extensions.Options;
using OT.Assessment.Data;

namespace OT.Assessment.App.Model;

public readonly struct PlayerServices(OnlineBettingDbContext dbContext, IOptions<PlayerOptions> options, ILogger<PlayerServices> logger)
{
    public OnlineBettingDbContext DbContext { get; } = dbContext;

    public IOptions<PlayerOptions> Options { get; } = options;

    public ILogger<PlayerServices> Logger { get; } = logger;
    
};
