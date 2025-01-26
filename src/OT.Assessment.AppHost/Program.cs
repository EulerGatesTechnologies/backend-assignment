var builder = DistributedApplication.CreateBuilder(args);

// Register a RabbitMQ server
var messaging = builder.AddRabbitMQ("messaging");

builder.AddProject<Projects.OT_Assessment_Consumer>("ot-assessment-consumer");

builder.Build().Run();
