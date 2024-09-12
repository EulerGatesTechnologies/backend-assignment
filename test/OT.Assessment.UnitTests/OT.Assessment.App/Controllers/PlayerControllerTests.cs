using Microsoft.AspNetCore.Http.HttpResults;
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
            var expectedOkResult = _playerController.GetPlayerWagers(playerId);

            // Assert
            var wagers = Assert.IsAssignableFrom<Ok<IEnumerable<CasinoWager>>>(expectedOkResult);
            
            Assert.NotNull(wagers.Value);
        }
    }
}