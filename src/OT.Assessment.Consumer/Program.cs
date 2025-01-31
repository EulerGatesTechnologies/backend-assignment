using Microsoft.AspNetCore.Builder;
using OT.Assessment.Consumer;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

// Add RabbitMQ client, connectonName should match the server name, here, 'messaging'.
builder.AddRabbitMQClient(connectionName: "messaging");

builder.Services.AddHostedService<PlayerCasinoWagersEventsProcessingJob>();

var host = builder.Build();

host.Run();


