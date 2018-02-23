using IMuaythai.JudgingServer;
using IMuaythai.JudgingServer.Handlers;
using IMuaythai.JudgingServer.RingMapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class WebSocketManagerExtensions
    {
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddScoped<WebSocketConnectionManager>();
            services.AddScoped<IMessageHandlerChainFactory, MessageHandlerChainFactory>();
            services.AddScoped(typeof(RingA));
            services.AddScoped(typeof(RingB));
            services.AddScoped(typeof(RingC));

            return services;
        }

        public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app,
                                                              PathString path,
                                                              WebSocketHandler handler)
        {
            return app.Map(path, (_app) => _app.UseMiddleware<WebSocketManagerMiddleware>(handler));
        }
    }
}
