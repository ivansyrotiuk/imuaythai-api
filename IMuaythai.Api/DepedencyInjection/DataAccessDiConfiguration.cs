using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.DataAccess.Services;
using IMuaythai.DataAccess.Services.Comparers;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class DataAccessDiConfiguration
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IEqualityComparer<ContestCategoriesMapping>, ContestCategoriesMappingEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestCategory>, ContestCategoryEqualityComparer>();
            services.AddScoped<IEqualityComparer<Contest>, ContestEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestRange>, ContestRangeEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestRequest>, ContestRequestEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestType>, ContestTypeEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestTypePoints>, ContestTypePointsEqualityComparer>();
            services.AddScoped<IEqualityComparer<Fight>, FightEqualityComparer>();
            services.AddScoped<IEqualityComparer<FightJudgesMapping>, FightJudgesMappingEqualityComparer>();
            services.AddScoped<IEqualityComparer<FightStructure>, FightStructureEqualityComparer>();
            services.AddScoped<IEqualityComparer<Round>, RoundEqualityComparer>();
            services.AddScoped<IEqualityComparer<WeightAgeCategory>, WeightAgeCategoryEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestRing>, ContestRingEqualityComparer>();

            services.AddScoped<IDataTransferService, DataTransferService>();
            services.AddScoped<IContextFactoryFacade, ContextFactoryFacade>();
        }
    }
}
