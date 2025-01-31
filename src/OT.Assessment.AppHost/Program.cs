var builder = DistributedApplication.CreateBuilder(args);

// Register a RabbitMQ server
var rabbitMq = builder.AddRabbitMQ("messaging");

var playerApi = builder.AddProject<Projects.OT_Assessment_App>("ot-assessment-app")
    .WithReference(rabbitMq);

builder.AddProject<Projects.OT_Assessment_Consumer>("ot-assessment-consumer")
    .WithReference(rabbitMq);

// Inject assigned URLs for Player API
//playerApi.WithEnvironment("PlayerOptions__ApiUrlHostAddress", () => playerApi.GetEndpoint("http").Host);

builder.Build().Run();
