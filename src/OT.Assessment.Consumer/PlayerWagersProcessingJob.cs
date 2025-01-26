using System.Text;
using OT.Assessment.Core;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OT.Assessment.Consumer
{
    /// <summary>
    /// This service will consume messages published to the aforementioned queue and store consumed messages in a database:
    /// </summary>
    public class PlayerCasionWagersEventsProcessingJob : BackgroundService
    {
        private readonly ILogger<PlayerCasionWagersEventsProcessingJob> _logger;
        
        private readonly IServiceProvider _serviceProvider;
        private IConnectionFactory _connectionFactory;
        private IModel _messageChannel;

        public PlayerCasionWagersEventsProcessingJob(ILogger<PlayerCasionWagersEventsProcessingJob> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
           
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker stopped at: {time}", DateTimeOffset.Now);
                return Task.FromCanceled(stoppingToken); 
            }

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            string queueName  = AppConsts.PlayerEvents;
            
            _connectionFactory = _serviceProvider.GetRequiredService<IConnectionFactory>();

            _messageChannel = _connectionFactory.CreateConnection().CreateModel();

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

        public void ProcessMessageAsync (object sender, BasicDeliverEventArgs args)
        {

            string messagetext = Encoding.UTF8.GetString(args.Body.ToArray());

            _logger.LogInformation("All wagers retrieved from the player at {now}. Message Text: {text}", DateTime.UtcNow, messagetext);            
        }
    }
}