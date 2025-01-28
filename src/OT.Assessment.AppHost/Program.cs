var builder = DistributedApplication.CreateBuilder(args);

// Register a RabbitMQ server
var messaging = builder.AddRabbitMQ("messaging");

var playerApi = builder.AddProject<Projects.OT_Assessment_App>("ot-assessment-app")
    .WithReference(messaging);

builder.AddProject<Projects.OT_Assessment_Consumer>("ot-assessment-consumer")
    .WithReference(messaging);

// Inject assigned URLs for Player API
playerApi.WithEnvironment("PlayerOptions__ApiUrlHostAddress", () => playerApi.GetEndpoint("http").Host);

builder.Build().Run();
