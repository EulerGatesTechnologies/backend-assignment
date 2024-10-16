using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OT.Assessment.App.Controllers;
using OT.Assessment.App.Model;
using OT.Assessment.Data;

namespace OT.Assessment.UnitTests.OT.Assessment.App.Controllers
{
    public class PlayerControllerTests
    {
        private readonly PlayerController _playerController = new();

        [Fact]
        public async Task CanGetPlayerWagers()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var paginationRequest = new PaginationRequest();
            var playerServices = new PlayerServices(null, null, null);

            // Act
            var expectedOkResult = await _playerController.GetWagersByPlayerIdAsync(paginationRequest, playerServices, playerId);

            // Assert
            var wagers = Assert.IsAssignableFrom<Ok<IEnumerable<PlayerCasinoWager>>>(expectedOkResult);
            
            Assert.NotNull(wagers.Value);
        }
    }
}