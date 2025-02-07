using OT.Assessment.App.Extensions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc; // Add this line for MVC support
using OT.Assessment.App.Models.CasinoWagers.Dtos; // Use the correct DTO

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.AddServiceDefaults();
webApplicationBuilder.AddApplicationServices();
webApplicationBuilder.AddRabbitMQClient(connectionName: "messaging");
webApplicationBuilder.Services.AddProblemDetails();
webApplicationBuilder.Services.AddControllers();
webApplicationBuilder.Services.AddEndpointsApiExplorer();
webApplicationBuilder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var webApplication = webApplicationBuilder.Build();

webApplication.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseSwagger();
    webApplication.UseSwaggerUI(opts =>
    {
        opts.EnableTryItOutByDefault();
        opts.DocumentTitle = "OT Assessment App";
        opts.DisplayRequestDuration();
    });
}

webApplication.UseHttpsRedirection();
webApplication.UseAuthorization();

// Define the API endpoint for POST
webApplication.MapPost("api/player/casinowager", async (PlayerCasinoWagerDto wagerDto) =>
{
    // Logic to publish wager to RabbitMQ
    // Example: await rabbitMq.PublishAsync(wagerDto);
});

webApplication.MapGet("api/player/{playerId}/casino", async (string playerId) =>
{
    // Logic to retrieve casino wagers for a specific player
});

webApplication.MapGet("api/player/topSpenders", async (int count) =>
{
    // Logic to retrieve top spenders
});

webApplication.MapControllers();
webApplication.Run();

// Required to access this class for Tests, otherwise, its internal access defined by default.
public partial class Program { }
