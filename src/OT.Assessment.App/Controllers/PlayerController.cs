using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using OT.Assessment.App.Models;
using OT.Assessment.Data;

namespace OT.Assessment.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController(IRepository repository) : ControllerBase
    {
       
        ///<summary>
        /// Receives player casino wager events to publish to the local RabbitMQ queue.
        /// </summary>
        /// <param name="casinoWager"></param>

        //POST api/player/casinowager

        [HttpPost("casinowager")]
        public async Task<OkResult> PostCasinoWager([FromBody] PlayerCasinoWager casinoWager)
        {
            // TODO: Store, & return success

            return Ok(); // Placeholder response
        }

        /// <summary>
        /// Returns a paginated list of the latest casino wagers for a specific player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        
        //GET api/player/{playerId}/wagers
        [HttpGet("{playerId}/casino")]
        public async Task<IResult> GetPlayerWagersAsync(Guid playerId)
        {
            var wagers = await repository.GetPlayerCasinoWagersAsync(playerId);
            
            // Your logic to retrieve wagers for the player with the given playerId
            // For example:
            // var wagers = _wagerService.GetWagersByPlayerId(playerId);
            // return Ok(wagers);
            return TypedResults.Ok(new PaginatedItems<PlayerCasinoWager>(pageIndex: 0, pageSize: 0, count: 0 , data: wagers)); // Placeholder response
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
