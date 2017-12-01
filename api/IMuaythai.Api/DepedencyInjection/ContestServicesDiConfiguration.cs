using IMuaythai.Contests;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class ContestServicesDiConfiguration
    {
        public static void AddContestServices(this IServiceCollection services)
        {
            services.AddScoped<IContestsService, ContestsService>();
            services.AddScoped<IContestRequestsService, ContestRequestsService>();
        }
    }
}