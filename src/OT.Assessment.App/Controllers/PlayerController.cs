using System.Data;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OT.Assessment.App.Models;
using OT.Assessment.Core;

using RabbitMQ.Client;

using Dapper;

using OT.Assessment.App.Models.CasinoWagers.Dtos;
using OT.Assessment.App.Infrastructure;
using OT.Assessment.App.Extensions;
using OT.Assessment.App.Application;
using OT.Assessment.App.Application.Queries;
using OT.Assessment.App.Model;

namespace OT.Assessment.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IConnection _messageConnection;

        public PlayerController(IConnection messageConnection)
        {
            _messageConnection = messageConnection;
        }
        /// <summary>
        ///  Receives player casino wager events to publish to the local RabbitMQ queue.
        ///  </summary>
        /// <param name="casinoWager"></param>           

        //POST api/player/casinowager
        [HttpPost("casinowager")]
        public async Task<IResult> CreateCasinoWagerAsync([FromBody] CasinoWager casinoWager)
        {
            var casinoWagerAsJsonString = JsonSerializer.Serialize(casinoWager);

            byte[] body = Encoding.UTF8.GetBytes(casinoWagerAsJsonString);

            IModel channel = _messageConnection.CreateModel();

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
        /// <param name="playerId"></param>
        /// <returns></returns>

        //GET api/player/{playerId}/casino
        [HttpGet("{playerId}/casino")]
        public async Task<Results<Ok<PaginatedItems<CasinoWager>>, BadRequest<string>>> GetAllPlayerCasinoWagersAsync(Guid playerId)
        {    
            // TODO: Check if time allows for cached data before making DB calls, cached output would have to be implemented prior.
                     
           return TypedResults.Ok(new PaginatedItems<CasinoWager>(10, 0, 0, data: []));
        }

        /// <summary>
        /// Returns the top players based on their total spending.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        /// 

        //GET api/player/topSpenders?count=10
        [HttpGet("topSpenders")]
        public async Task<Results<Ok<IEnumerable<PlayerCasinoWagerDto>>> GetTopSpendersAsync(int count = 10)
        {
            string sql = @"sp_GetPlayerAccounts";

            try
            {
                using IDbConnection connection = new SqlConnection("SERVER=.; DATABASE=OT_Assessment_DB; Integrated Security=SSPI;");

                var playerCasinoWagers = await connection.QueryAsync<CasinoWager>(sql);

                // TODO: Check if time allows for cached data before making DB calls, cached output would have to be implemented prior.
                var topSpenders = playerCasinoWagers
                    .MapToPlayerCasinoWagerDtos()
                    .Take(count)
                    .ToList();

                return TypedResults.Ok(topSpenders); // Placeholder response
            }
            catch (Exception ex)
            {

                throw new DomainException(ex.Message, ex.InnerException);
            }                   
           
        }
    }
}
