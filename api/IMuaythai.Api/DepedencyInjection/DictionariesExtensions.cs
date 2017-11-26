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
            services.AddScoped<IRoundsSevice, RoundsService>();
            services.AddScoped<IKhanLevelsService, KhanLevelsService>();
            services.AddScoped<IFightStructuresService, FightStructuresService>();
            services.AddScoped<IContestTypesService, ContestTypesService>();

            return services;
        }
    }
}