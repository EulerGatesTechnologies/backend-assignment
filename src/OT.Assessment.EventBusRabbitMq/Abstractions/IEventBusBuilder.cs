using Microsoft.Extensions.DependencyInjection;

namespace OT.Assessment.EventBusRabbitMq.Abstractions
{
    public interface IEventBusBuilder
    {
        public IServiceCollection Services { get; }
    }
}
