using IMuaythai.Licenses;
using IMuaythai.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class LicenseServicesDiConfiguration
    {
        public static void AddLicenseServices(this IServiceCollection services)
        {
            services.AddScoped<ILicenseService, LicenseService>();
            services.AddScoped<ILicensePaymentService, LicensePaymentService>();
            services.AddScoped<IPaymentSigner, PaymentSigner>();
            services.AddScoped<ILicenseTypesService, LicenseTypesService>();
        }
    }
}