using IMuaythai.Dashboard;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class DashboardServicesDiConfiguration
    {
        public static void AddDashboardServices(this IServiceCollection services)
        {
            services.AddScoped<IContestEventsService, ContestEventsService>();
        }
    }
}