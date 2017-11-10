using IMuaythai.Users;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class UsersExtensions
    {
        public static IServiceCollection AddUsersServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();

            return services;
        }
    }
}