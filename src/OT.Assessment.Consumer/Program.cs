using OT.Assessment.Consumer;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.AddRabbitMQClient("messaging");

builder.Services.AddHostedService<PlayerCasinoWagersEventsProcessingJob>();

var host = builder.Build();

host.Run();


