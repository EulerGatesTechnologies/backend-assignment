using OT.Assessment.Consumer;
using RabbitMQ.Client;


var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.AddRabbitMQClient("messaging");

builder.Services.AddHostedService<PlayerCasinoWagersEventsProcessingJob>();


var host = builder.Build();

var connectionFactory = host.Services.GetService<IConnectionFactory>();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Consumer started at: {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

await host.RunAsync();

logger.LogInformation("Consumer ended at: {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
