var builder = DistributedApplication.CreateBuilder(args);

// Service registration

// Register a RabbitMQ Server
var messagingRabbitMq = builder.AddRabbitMQ("messaging");

// API Apps
builder.AddProject<Projects.OT_Assessment_App>("ot-assessment-app")
    .WithReference(messagingRabbitMq);

builder.Build().Run();
