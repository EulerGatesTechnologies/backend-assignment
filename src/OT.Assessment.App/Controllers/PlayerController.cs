using System.Data;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OT.Assessment.App.Model;
using OT.Assessment.App.Models;
using OT.Assessment.Core;

using RabbitMQ.Client;

using static OT.Assessment.Core.AppConsts;

using Dapper;
using OT.Assessment.App.DomainModels.Players.Dtos;
using OT.Assessment.App.Models.CasinoWagers.Dtos;

namespace OT.Assessment.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerServices _playerServices;        
        public PlayerController(PlayerServices playerServices)
        {
            _playerServices = playerServices;
        }

        /// <summary>
        ///  Receives player casino wager events to publish to the local RabbitMQ queue.
        ///  </summary>
        /// <param name="casinoWager"></param>      


        //POST api/player/casinowager
        [HttpPost("casinowager")]
        public async Task<IResult> CreateCasinoWagerAsync([FromBody] PlayerCasinoWagerDto casinoWager)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(casinoWager));

            // Send a message to the queue in RabbitMQ
            var factory = new ConnectionFactory { HostName = "localhost" };

            using IConnection connection = factory.CreateConnection();
           
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: AppConsts.PlayerEvents,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);            

            channel.BasicPublish(exchange: string.Empty,
                routingKey: AppConsts.PlayerEvents,
                basicProperties: null,
                body: body);

            return await Task.FromResult(TypedResults.Ok()); // Placeholder response
        }

        /// <summary>
        /// Returns a paginated list of the latest casino playerCasinoWagers for a specific player.
        /// </summary>
        /// <param name="paginationRequest"></param>
        /// <param name="services"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>

        //GET api/player/{playerId}/casino
        [HttpGet("{playerId}/casino")]
        public async Task<Ok<PaginatedItems<PlayerCasinoWagerDto>>> GetCasinoWagersByPlayerIdAsync([AsParameters] 
            PaginationRequest paginationRequest,
            Guid playerId)
        {
            string sql = @"sp_GetCasinoWagerByPlayerId";

            using IDbConnection connection = new SqlConnection(GetConnectionString());

            IEnumerable<PlayerCasinoWagerDto> playerCasinoWagers 
                =  await connection.QueryAsync<PlayerCasinoWagerDto>(sql, new { AccountId = playerId });

            int pageSize = paginationRequest.PageSize;
            int pageIndex = paginationRequest.PageIndex;

            // TODO: Check if time allows for cached data before making DB calls, cached output would have to be implemented prior.
            var wagersOnPage = playerCasinoWagers
                .OrderBy(w => w.CreatedDateTime)
                .Skip(pageSize)
                .Take(pageSize)
                .ToList();

            return TypedResults.Ok(new PaginatedItems<PlayerCasinoWagerDto>(pageIndex: paginationRequest.PageIndex, pageSize: paginationRequest.PageSize, count: 0 , data: wagersOnPage)); // Placeholder response
        }

        /// <summary>
        /// Returns the top players based on their total spending.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        //GET api/player/topSpenders?count=10
        [HttpGet("topSpenders")]
        public async Task<Ok<PaginatedItems<PlayerAccountDto>>> GetTopSpendersAsync(PlayerServices services, 
            int count = 10)
        {
     

            var playerParams = new DynamicParameters();
            playerParams.Add("@PlayerId", searchTerm); 
            
            string sql = @"sp_GetPlayerAccounts";

            using IDbConnection connection = new SqlConnection(GetConnectionString());

            var playerCasinoWagers = await connection.QueryAsync<PlayerCasinoWagerDto>(sql, playerParams);
            
            // TODO: Check if time allows for cached data before making DB calls, cached output would have to be implemented prior.
            var topSpenders = playerCasinoWagers
                .Where(pa => pa.Amount.)
                .OrderBy(w => w.CreatedDateTime)
                .Take(count)
                .ToList();

            return TypedResults.Ok(PaginatedItems<PlayerAccountDto>(pageIndex: paginationRequest.PageIndex, pageSize: paginationRequest.PageSize, count: 0, data: topSpenders)); // Placeholder response
        }
    }
}
