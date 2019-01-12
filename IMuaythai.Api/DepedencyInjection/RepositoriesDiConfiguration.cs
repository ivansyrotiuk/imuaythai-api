using IMuaythai.Licenses;
using IMuaythai.Repositories;
using IMuaythai.Repositories.Contests;
using IMuaythai.Repositories.Dictionaries;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{ 
    public static class RepositoriesDiConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IInstitutionsRepository, InstitutionsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IContestTypesRepository, ContestTypesRepository>();
            services.AddScoped<IContestRangesRepository, ContestRangesRepository>();
            services.AddScoped<IKhanLevelsRepository, KhanLevelRepository>();
            services.AddScoped<ISuspensionTypesRepository, SuspensionTypesRepository>();
            services.AddScoped<IFightRepository, FightRepository>();
            services.AddScoped<IContestTypePointsRepository, ContestTypePointsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUserRoleRequestsRepository, UserRoleRequestsRepository>();
            services.AddScoped<IContestRepository, ContestRepository>();
            services.AddScoped<IContestCategoriesRepository, ContestCategoriesRepository>();
            services.AddScoped<IContestRequestRepository, ContestRequestRepository>();
            services.AddScoped<IRoundsRepository, RoundsRepository>();
            services.AddScoped<IWeightAgeCategoriesRepository, WeightAgeCategoriesRepository>();
            services.AddScoped<IFightStructuresRepository, FightStructuresRepository>();
            services.AddScoped<IContestCategoryMappingsRepository, ContestCategoryMappingsRepository>();
            services.AddScoped<IContestRingsRepository, ContestRingsRepository>();
            services.AddScoped<IFightsRepository, FightsRepository>();
            services.AddScoped<IDocumentsRepository, DocumentsRepository>();
            services.AddScoped<ILicenseTypesRepository, LicenseTypesRepository>();
            services.AddScoped<ILicensesRepository, LicensesRepository>();
        }
    }
}