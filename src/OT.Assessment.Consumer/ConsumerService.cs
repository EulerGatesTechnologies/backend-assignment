using RabbitMQ.Client;

namespace OT.Assessment.Consumer;

// This class will contain the consumer service logic that will consume messages from the RabbitMQ queue.
public class ConsumerService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IRepository _repository;

    public ConsumerService(string rabbitMqConnectionString, IRepository repository)
    {
        _connection = ConnectionFactory.CreateConnection(rabbitMqConnectionString);
        _channel = _connection.CreateModel();
        _repository = repository;
    }

    public void StartConsuming()
    {
        _channel.BasicQos(0, 1, false);
        _channel.BasicConsume(queue: "casino_wagers", onMessage: (model, message) =>
        {
            var body = message.Body;
            var wager = JsonConvert.DeserializeObject<PlayerCasinoWager>(body);
            _repository.AddPlayerCasinoWagerAsync(wager).Wait();
            _channel.BasicAck(deliveryTag: message.DeliveryTag, multiple: false);
        });
    }

}