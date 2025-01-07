
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OT.Assessment.Consumer;
using OT.Assessment.Consumer.Extensions;

var builder = Host.CreateApplicationBuilder(args);

// Reference below package found in ASPIRE's ServiceDefaults projects in the current workspac/solution.
builder.AddServiceDefaults();

builder.AddRabbitMQClient("messaging");

builder.AddRabbitMqEventBus("EventBus");

builder.Services.AddHostedService<PlayerWagersProcessingJob>();

builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();
// Start consuming messages as soon as the application starts
builder.Services.AddSingleton<IHostedService>(sp => (RabbitMQEventBus)sp.GetRequiredService<IEventBus>());

return new EventBusBuilder(builder.Services);

var host = builder.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Application started {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

await host.RunAsync();

logger.LogInformation("Application ended {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
