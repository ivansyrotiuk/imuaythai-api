using IMuaythai.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class CommonServicesDiConfiguration
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, AuthMessageSender>();
            services.AddScoped<ISmsSender, AuthMessageSender>();
        }
    }
}