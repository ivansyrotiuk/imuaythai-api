using Microsoft.AspNetCore.Builder;

namespace IMuaythai.Api.Middleware
{
    internal static class MiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}