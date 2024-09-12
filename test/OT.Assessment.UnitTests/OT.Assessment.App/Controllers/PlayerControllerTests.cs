using Microsoft.AspNetCore.Mvc;
using OT.Assessment.App.Controllers;
using OT.Assessment.Tester.Infrastructure;

namespace OT.Assessment.UnitTests.OT.Assessment.App.Controllers
{
    public class PlayerControllerTests
    {
        private readonly PlayerController _playerController;

        public PlayerControllerTests()
        {
            _playerController = new PlayerController();
        }

        [Fact]
        public void CanGetPlayerWagers()
        {
            // Arrange
            var playerId = Guid.NewGuid();

            // Act
            var result = _playerController.GetPlayerWagers(playerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var wagers = Assert.IsAssignableFrom<IEnumerable<CasinoWager>>(okResult.Value);
            
            Assert.NotEmpty(wagers);
        }
    }
}