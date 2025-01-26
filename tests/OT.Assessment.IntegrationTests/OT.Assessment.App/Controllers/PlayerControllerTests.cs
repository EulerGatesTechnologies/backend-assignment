using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Numerics;
using System.Text.Json;

using Xunit;

using OT.Assessment.Core.Entities;
using OT.Assessment.App.Models.CasinoWagers.Dtos;
using OT.Assessment.Tester.Infrastructure;

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
            
            string url = $"{hostAddress}/player/{playerId}/casino";
            
            // Act 
            var response = await httpClient.GetAsync(url);
            
            // Assert
            Assert.NotNull(response);
            
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
            
            var content = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(content);

            var playerWager = JsonSerializer.Deserialize<CasinoWager>(content);

            Assert.NotNull(playerWager);
            
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
