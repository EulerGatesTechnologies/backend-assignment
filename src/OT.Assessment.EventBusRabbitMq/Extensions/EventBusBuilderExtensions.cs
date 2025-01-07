using OT.Assessment.EventBusRabbitMq.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace OT.Assessment.EventBusRabbitMq.Extensions
{
    public static class EventBusBuilderExtensions
    {
        public static IEventBusBuilder ConfigureJsonOptions(this IEventBusBuilder eventBusBuilder, Action<JsonSerializerOptions> configure)
        {
            eventBusBuilder.Services.Configure<EventBusSubscriptionInfo>(o =>
            {
                configure(o.JsonSerializerOptions);
            });

            return eventBusBuilder;
        }
    }
}
