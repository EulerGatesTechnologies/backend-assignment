using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OT.Assessment.Consumer
{
    /// <summary>
    /// This service will consume messages published to the aforementioned queue and store consumed messages in a database:
    /// </summary>
    public class PlayerCasinoWagersEventsProcessingJob : BackgroundService
    {
        private readonly ILogger<PlayerCasinoWagersEventsProcessingJob> _logger;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private IConnection _messageConnection;
        private IModel _messageChannel;

        public PlayerCasinoWagersEventsProcessingJob(ILogger<PlayerCasinoWagersEventsProcessingJob> logger, IConfiguration config, IServiceProvider serviceProvider, IConnection messageConnection)
        {
            _logger = logger;
            _config = config;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested == true)
            {
                _logger.LogInformation("Worker stopped at: {time}, with IsCancellationRequested: {cancellationToken}", DateTime.UtcNow, stoppingToken.IsCancellationRequested);

                return Task.FromCanceled(stoppingToken); 
            }

            _logger.LogInformation("Worker running at: {time}", DateTime.UtcNow);

            string queueName  = "PlayerEvents";

            _messageConnection = _serviceProvider.GetService<IConnection>();

            _messageChannel = _messageConnection.CreateModel();

            _messageChannel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _logger.LogInformation($"[*] Waiting for messages from queue channel named : {queueName}");

            var consumer = new EventingBasicConsumer(_messageChannel);

            consumer.Received += ProcessMessageAsync;

            _messageChannel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: consumer);

            return Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken); 

            _messageChannel?.Dispose();
        }

        public void ProcessMessageAsync (object? sender, BasicDeliverEventArgs args)
        {
            
            string messagetext = Encoding.UTF8.GetString(args.Body.ToArray());

            _logger.LogInformation("All wagers retrieved from the player at {now}. Message Text: {text}", DateTime.UtcNow, messagetext);            
        }
    }
}