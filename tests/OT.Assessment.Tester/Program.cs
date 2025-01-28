// See https://aka.ms/new-console-template for more information


using OT.Assessment.App.Infrastructure;

var bg = new BogusGenerator();

List<CasinoWager> fakePlayerCasinoWagers = bg.Generate();

var scenario = Scenario.Create("POST_PlayerCasinoWagers_Events_Scenario", async context =>
    {
        string body = JsonSerializer.Serialize(fakePlayerCasinoWagers[(int)context.InvocationNumber]);

        using var httpClient = new HttpClient();

        var request =
           Http.CreateRequest("POST", "http://localhost:5021/api/Player/casinowager")
                .WithHeader("Accept", "application/json")
                .WithBody(new StringContent($"{body}", Encoding.UTF8, "application/json"));

        var response = await Http.Send(httpClient, request);

        if (response.StatusCode == "OK") return Response.Ok();
        return Response.Fail(body, response.StatusCode, response.Message, response.SizeBytes);
    })
    .WithoutWarmUp()
    .WithLoadSimulations(
        Simulation.IterationsForInject(rate: 500,
            interval: TimeSpan.FromSeconds(2),
            iterations: 7000)
    );

NBomberRunner
    .RegisterScenarios( scenario )
    .WithWorkerPlugins(new HttpMetricsPlugin(new[] { HttpVersion.Version1 }))
    .WithoutReports()
    .Run();