using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using OT.Assessment.App.Infrastructure;

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

        // TODO: Implement the below test case with GET method urls
        [Theory]        
        [InlineData("http://localhost:5021/api/Player/aa6700eb-1a06-483e-9739-d293dc7a9383/casino")]
        [InlineData("http://localhost:5021/api/player/topSpenders?count=10")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange            
            var httpClient = _factory.CreateClient();

            // Act
            var response = await httpClient.GetAsync(url);

            // Assert
            Assert.NotNull(response);

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(content);

            var playerWager = JsonSerializer.Deserialize<CasinoWager>(content);

            Assert.NotNull(playerWager);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
