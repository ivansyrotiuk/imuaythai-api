using IMuaythai.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class AuthServicesDiConfiguration
    {
        public static void AddAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IHttpUserContext, HttpUserContext>();
        }
    }
}