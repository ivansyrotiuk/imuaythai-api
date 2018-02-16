using IMuaythai.CloudinaryFiles;
using IMuaythai.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class SharedDiConfiguration
    {
        public static void AddSharedServices(this IServiceCollection services)
        {
            services.AddScoped<IFileSaver, CloudinaryFileSaver>();
            services.AddScoped<IBase64StringExtractor, Base64StringExtractor>();
            services.AddScoped<IFilesService, CloudinaryFilesService>();
        }
    }
}