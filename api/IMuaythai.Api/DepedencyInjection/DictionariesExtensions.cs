using IMuaythai.Dictionaries;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class DictionariesExtensions
    {
        public static IServiceCollection AddDictionariesServices(this IServiceCollection services)
        {
            services.AddScoped<IContestCategoriesService, ContestCategoriesService>();
            services.AddScoped<IWeightAgeCategoriesService, WeightAgeCategoriesService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IContestRangesService, ContestRangesService>();

            return services;
        }
    }
}