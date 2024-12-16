using Microsoft.AspNetCore.Http.HttpResults;
using OT.Assessment.App.Controllers;
using OT.Assessment.App.Model;

namespace OT.Assessment.UnitTests.OT.Assessment.App.Controllers
{
    public class PlayerControllerTests
    {
        private readonly PlayerController _playerController = new();
        private object playerService;

        [Fact]
        public async Task GetPlayerWagers()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var paginationRequest = new PaginationRequest();
            IPlayerAppService playerAppService = new(PlayerServices playerService);

            // Act
            var expectedOkResult = await playerAppService.;

            // Assert
            var wagers = Assert.IsAssignableFrom<Ok<IEnumerable<PlayerCasinoWager>>>(expectedOkResult);
            
            Assert.NotNull(wagers.Value);
        }
    }
}