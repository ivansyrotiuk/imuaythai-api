using IMuaythai.Auth;
using IMuaythai.HttpServices;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class HttpServicesDiConfiguration
    {
        public static void AddHttpServices(this IServiceCollection services)
        {
            services.AddScoped<IHttpUserContext, HttpUserContext>();
        }
    }
}