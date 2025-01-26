using Microsoft.AspNetCore.Http.HttpResults;
using OT.Assessment.App.Model;
using OT.Assessment.Tester.Infrastructure;

namespace OT.Assessment.App.Apis
{
    public static class PlayersApi
    {
        public static IEndpointRouteBuilder MapPlayerApiV1(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/player");

            // Routes for querying catalog items.
            api.MapGet("{playerId}/casino", GetPlayerCasinoWagersAsync);           

            return app;
        }

        public static async Task<Results<Ok<IEnumerable<CasinoWager>>, NotFound>> GetPlayerCasinoWagersAsync(Guid playerId, [AsParameters] PlayerServices services)
        {
            try
            {
                var casinoWagers = await services.Queries.GetPlayerCasinoWagersAsync(playerId.ToString());

                return TypedResults.Ok(casinoWagers);
            }
            catch
            {
                return TypedResults.NotFound();
            }
        }
    }
}
