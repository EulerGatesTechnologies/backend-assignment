using Microsoft.AspNetCore.Mvc;

namespace OT.Assessment.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        //POST api/player/casinowager

        //[HttpPost("casinowager")]
        //public IActionResult PostCasinoWager([FromBody] CasinoWager casinoWager)
        //{
        //    if (casinoWager == null)
        //    {
        //        return BadRequest("CasinoWager is null.");
        //    }
        //     Your logic to handle the posted casino wager
        //     For example:
        //     _wagerService.AddCasinoWager(casinoWager);
        //     return CreatedAtAction(nameof(GetPlayerWagers), new { playerId = casinoWager.PlayerId }, casinoWager);
        //    return Ok(); // Placeholder response
        //}

        //GET api/player/{playerId}/wagers

        // TODO: Write Unit Test for the method below
        //[HttpGet("{playerId}/wagers")]
        //public IActionResult GetPlayerWagers(Guid playerId)
        //{
        //    // Your logic to retrieve wagers for the player with the given playerId
        //    // For example:
        //    // var wagers = _wagerService.GetWagersByPlayerId(playerId);
        //    // return Ok(wagers);
        //    return Ok(); // Placeholder response
        //}

        //GET api/player/topSpenders?count=10

        //public IActionResult GetTopSpenders([FromQuery] int count = 10)
        //{
        //    // Your logic to retrieve the top spenders
        //    // For example:
        //    // var topSpenders = _playerService.GetTopSpenders(count);
        //    // return Ok(topSpenders);
        //    return Ok(); // Placeholder response
        //}
    }
}
