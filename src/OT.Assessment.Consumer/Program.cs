
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OT.Assessment.Consumer;



var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.AddRabbitMQClient("messaging");


builder.Services.AddHostedService<PlayerWagersProcessingJob>();

var host = builder.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Application started {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

await host.RunAsync();

logger.LogInformation("Application ended {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
