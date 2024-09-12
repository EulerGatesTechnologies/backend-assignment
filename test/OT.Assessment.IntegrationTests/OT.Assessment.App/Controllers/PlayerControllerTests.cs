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

            const string hostAddress = $"http://localhost:5021/api";
            
            Guid playerId = Guid.NewGuid();
            
            string url = $"{hostAddress}/player/{playerId}/wagers";
            
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

            Assert.NotNull(playerWagers.Where(cw =>
                string.Equals(cw.AccountId, playerId.ToString(), StringComparison.Ordinal)));
        }

        // TODO: Implement the below test case with GET method urls
        //[Theory]
        //[InlineData("/")]
        //[InlineData("/Index")]
        //[InlineData("/About")]
        //[InlineData("/Privacy")]
        //[InlineData("/Contact")]
        //public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    // Act
        //    var response = await client.GetAsync(url);

        //    // Assert
        //    response.EnsureSuccessStatusCode(); // Status Code 200-299
        //    Assert.Equal("text/html; charset=utf-8",
        //        response.Content.Headers.ContentType.ToString());
        //}
    }
}
