using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Numerics;
using System.Text.Json;
using OT.Assessment.Tester.Infrastructure;
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
            var httpClient = _factory.CreateClient();

            const string hostAddress = $"http://localhost:5021";
            
            Guid playerId = Guid.NewGuid();
            
            string url = $"{hostAddress}/api/player/{playerId}/wagers";
            
            // Act 
            var response = await httpClient.GetAsync(url);
            
            // Assert
            Assert.NotNull(response);
            
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
            
            var content = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(content);

            var playerWagers = JsonSerializer.Deserialize<IEnumerable<CasinoWager>>(content);

            Assert.NotNull(playerWagers);
            Assert.NotEmpty(playerWagers);
            //Assert.True(playerWagers.Where(cw.AccountId == playerId));
        }
    }
}
