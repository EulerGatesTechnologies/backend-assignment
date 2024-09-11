using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Numerics;
using System.Text.Json;
using Xunit;

namespace OT.Assessment.IntegrationTests.OT.Assessment.App.Controllers
{
    //TODO: Use Shouldly for fluent assertions
    public class PlayerControllerTests 
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public PlayerControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CanReadPlayers()
        {
            // Arrange
            var client = _factory.CreateClient();
            
            Guid playerId = Guid.NewGuid();
            
            string url = $"/api/player/{playerId}/wagers";
            
            // Act 
            var response = await client.GetAsync(url);
            
            // Assert
            Assert.NotNull(response);
            
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            
            var content = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(content);

            var playerWagers = JsonSerializer.Deserialize<IEnumerable<CasinoWager>>(content);

            Assert.NotNull(playerWagers);
            Assert.NotEmpty(playerWagers);
            Assert.IsTrue(playerWagers.Where(cw.AccountId == playerId));
        }
    }
}
