using IMuaythai.Institutions;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class InstitutionServicesDiConfiguration
    {
        public static void AddInstitutionsServices(this IServiceCollection services)
        {
            services.AddScoped<IInstitutionsService, InstitutionsService>();
            services.AddScoped<IGymsService, GymsService>();
            services.AddScoped<IFederationsService, FederationsService>();
        }
    }
}
