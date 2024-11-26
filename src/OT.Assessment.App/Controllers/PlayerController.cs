using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OT.Assessment.App.Infrastructure;
using OT.Assessment.App.Model;
using OT.Assessment.App.Models;
using OT.Assessment.Core;

using RabbitMQ.Client;

namespace OT.Assessment.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///  Receives player casino wager events to publish to the local RabbitMQ queue.
        ///  </summary>
        /// <param name="casinoWager"></param>
        /// <param name="services"></param>
        /// <param name="connection"></param>

        //POST api/player/casinowager
        [HttpPost("casinowager")]
        public async Task<IResult> PostPlayerWagerAsync([FromBody] CasinoWager casinoWager)
        {
            // Send a message to the queue in RabbitMQ
            var factory = new ConnectionFactory { HostName = "localhost" };

            using IConnection connection = factory.CreateConnection();
           
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: CoreConsts.QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = JsonSerializer.Serialize(casinoWager);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                routingKey: CoreConsts.QueueName,
                basicProperties: null,
                body: body);

            return TypedResults.Ok(); // Placeholder response
        }

        /// <summary>
        /// Returns a paginated list of the latest casino wagers for a specific player.
        /// </summary>
        /// <param name="paginationRequest"></param>
        /// <param name="services"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>

        //GET api/player/{playerId}/wagers
        [HttpGet("{playerId}/wagers")]
        public async Task<Ok<PaginatedItems<PlayerCasinoWager>>> GetWagersByPlayerIdAsync([FromQuery]
            [AsParameters] PaginationRequest paginationRequest,
            [AsParameters] PlayerServices services,
            Guid playerId)
        {
            //string query = @"sp_GetWagersByPlayerIdAsync";
            //using var connection = services.DbContext.Database.GetDbConnection();
            //var wagers = await connection.QueryAsync<PlayerCasinoWager>(query, new { AccountId = playerId });
            int pageSize = paginationRequest.PageSize;
            int pageIndex = paginationRequest.PageIndex;

            // TODO: Check if time allows for cached data before making DB calls, cached output would have to be implemented prior.
            var wagersOnPage = await services.DbContext.PlayerCasinoWagers
                .OrderBy(w => w.CreatedDateTime)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return TypedResults.Ok(new PaginatedItems<PlayerCasinoWager>(pageIndex: paginationRequest.PageIndex, pageSize: paginationRequest.PageSize, count: 0 , data: wagersOnPage)); // Placeholder response
        }

        /// <summary>
        /// Returns the top players based on their total spending.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        //GET api/player/topSpenders?count=10
        [HttpGet("topSpenders")]
        public async Task<Ok<PaginatedItems<PlayerAccount>>> GetTopSpendersAsync([FromQuery]
            [AsParameters] PaginationRequest paginationRequest,
            [AsParameters] PlayerServices services, int count = 10)
        {
            // Your logic to retrieve the top spenders
            // For example:
            var topSpenders = services.DbContext.PlayerAccounts.ToListAsync<PlayerAccount>;

            int pageSize = paginationRequest.PageSize;
            int pageIndex = paginationRequest.PageIndex;

            // TODO: Check if time allows for cached data before making DB calls, cached output would have to be implemented prior.
            var wagersOnPage = await services.DbContext.PlayerAccounts
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return TypedResults.Ok(new PaginatedItems<PlayerAccount>(pageIndex: paginationRequest.PageIndex, pageSize: paginationRequest.PageSize, count: 0, data: wagersOnPage)); // Placeholder response
        }
    }
}
