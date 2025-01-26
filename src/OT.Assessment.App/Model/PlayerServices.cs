using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using OT.Assessment.Core;
using OT.Assessment.Core.Entities;
using OT.Assessment.Tester.Infrastructure;
using Dapper;
using RabbitMQ.Client;
using OT.Assessment.App.Application.Queries;

namespace OT.Assessment.App.Model;

public class PlayerServices(IConnectionFactory connectionFactory, IOptions<PlayerOptions> options, ILogger<PlayerServices> logger)
{
    public IConnectionFactory ConnectionFactory { get; } = connectionFactory;
    public IOptions<PlayerOptions> Options { get; } = options;
    public ILogger<PlayerServices> Logger { get; } = logger;
    public IPlayerQueries Queries { get; internal set; }
};
