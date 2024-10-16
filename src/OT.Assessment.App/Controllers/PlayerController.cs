using System.Collections;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Model;
using OT.Assessment.App.Models;
using OT.Assessment.Data;
using OT.Assessment.Tester.Infrastructure;
using RabbitMQ.Client;
using CasinoWager = OT.Assessment.App.Infrastructure.CasinoWager;

namespace OT.Assessment.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly OnlineBettingDbContext _onlineBettingDbContext;

        // TODO: Used for QUICK Tests, otherwise to use DIs.
        public PlayerController()
        {
           
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

            channel.QueueDeclare(queue: "playerWagersEvents",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = "Getting all items in the catalog.";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                routingKey: "playerWagersEvents",
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
        public async Task<IResult> GetTopSpendersAsync([FromQuery] int count = 10)
        {
            // Your logic to retrieve the top spenders
            // For example:
            // var topSpenders = _playerService.GetTopSpenders(count);
            // return Ok(topSpenders);
            return TypedResults.Ok(new List<PlayerAccount>()); // Placeholder response
        }
    }
}
