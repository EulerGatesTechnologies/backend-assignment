using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using OT.Assessment.App.Application.Queries;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace OT.Assessment.App.Model;

public class PlayerServices(DbContext dbContext, IConnectionFactory connectionFactory, IOptions<PlayerOptions> options, ILogger<PlayerServices> logger, IPlayerQueries playerQueries, IDbConnection connection)
{
    public DbContext DbContext { get; } = dbContext;
    public IConnectionFactory ConnectionFactory { get; } = connectionFactory;
    public IOptions<PlayerOptions> Options { get; } = options;
    public ILogger<PlayerServices> Logger { get; } = logger;
    public IPlayerQueries PlayerQueries { get; } = playerQueries;
    public IDbConnection Connection { get; } = connection;
};
