using Microsoft.Extensions.Configuration;
using OT.Assessment.Consumer;
using RabbitMQ.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var rabbitMqConnectionString = "amqp://guest:guest@localhost";
            var dbContextOptions = new DbContextOptionsBuilder<OnlineBettingDbContext>()
                .UseSqlServer("SERVER=localhost; DATABASE=OT_Assessment_DB; Integrated Security=SSPI;")
                .Options;

            using var context = new OnlineBettingDbContext(dbContextOptions);
            var repository = new Repository(context);

            var consumerService = new ConsumerService(rabbitMqConnectionString, repository);
            consumerService.StartConsuming();

            Console.WriteLine("Consumer started. Press any key to exit.");
            Console.ReadKey();

            
        var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    })
    .ConfigureServices((context, services) =>
    {
        //configure services

    })
    .Build();

        var logger = host.Services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Application started {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

        await host.RunAsync();

        logger.LogInformation("Application ended {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
    }
}