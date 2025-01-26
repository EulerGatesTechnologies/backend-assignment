using OT.Assessment.App.Model;

namespace OT.Assessment.App.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.Services.AddOptions<PlayerOptions>();            
        }
    }
}
