using Microsoft.Extensions.Options;

namespace OT.Assessment.App.Extensions
{
    public static class HostingExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.Services.Configure<PlayerOptions>(builder.Configuration.GetSection(nameof(PlayerOptions)));              
            
        }

        public static TOptions GetOptions<TOptions>(this IHost host)
        where TOptions : class, new()
        {
            return host.Services.GetRequiredService<IOptions<TOptions>>().Value;
        }
    }
}
