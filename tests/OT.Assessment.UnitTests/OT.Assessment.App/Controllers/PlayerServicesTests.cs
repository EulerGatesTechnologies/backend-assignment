using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using OT.Assessment.App.Model;

namespace OT.Assessment.UnitTests.OT.Assessment.App.Model;


public class PlayerServicesTests : IClassFixture<WebApplicationFactory<Program>>
{
    private PlayerServices _services;

    private readonly WebApplicationFactory<Program> _factory;

    
    public PlayerServicesTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public void CanCreatePlayerServicesInstance()
    {
        // Precondition
        Assert.NotNull(_factory);

        // Act
        _services = _factory.Services.GetService<PlayerServices>();

        // Assert
        Assert.NotNull(_services);

    }

    [Fact]
    public async Task GetPlayerWagers()
    {
        //// Arrange
        var playerId = Guid.NewGuid();
        
        var playerServices = new PlayerServices(null, null, null, null,null,null);
        
        var playerCasinoWagers = playerServices.PlayerQueries.GetPlayerCasinoWagersAsync(playerId.ToString()); ;

        

        //// Act
        //var expectedOkResult = await playerAppService.;

        //// Assert
        //var wagers = Assert.IsAssignableFrom<Ok<IEnumerable<CasinoWager>>>(expectedOkResult);

        //Assert.NotNull(wagers.Value);
    }
}