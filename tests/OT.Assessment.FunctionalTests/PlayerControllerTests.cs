namespace OT.Assessment.FunctionalTests;

using Xunit;

public class PlayerControllerTests
{

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()//EndpointsReturnSuccessAndCorrectContentType
    {
        //     // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.OT_Assessment_AppHost>();
        //     appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        //     {
        //         clientBuilder.AddStandardResilienceHandler();
        //     });
        //     // To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging
        //
        //     await using var app = await appHost.BuildAsync();
        //     var resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();
        //     await app.StartAsync();

        //     // Act
        //     var httpClient = app.CreateHttpClient("webfrontend");
        //     await resourceNotificationService.WaitForResourceAsync("webfrontend", KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(30));
        //     var response = await httpClient.GetAsync("/");

        //     // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
