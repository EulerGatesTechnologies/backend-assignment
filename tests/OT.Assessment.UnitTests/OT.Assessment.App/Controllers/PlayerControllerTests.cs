using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using OT.Assessment.App.Controllers;
using OT.Assessment.App.Model;
using OT.Assessment.Tester.Infrastructure;

namespace OT.Assessment.UnitTests.OT.Assessment.App.Controllers
{
    public class PlayerControllerTests
    {
        private readonly PlayerController _playerController = new();
        private object playerService;

        [Fact]
        public async Task GetPlayerWagers()
        {
            //// Arrange
            //var playerId = Guid.NewGuid();
            //var paginationRequest = new PaginationRequest();
            //PlayerServices playerServices = new();

            //// Act
            //var expectedOkResult = await playerAppService.;

            //// Assert
            //var wagers = Assert.IsAssignableFrom<Ok<IEnumerable<CasinoWager>>>(expectedOkResult);
            
            //Assert.NotNull(wagers.Value);
        }
    }
}