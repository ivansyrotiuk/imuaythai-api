using FluentValidation;
using IMuaythai.Api.Validators;
using IMuaythai.Models.Dictionaries;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class FluentValidationDiConfiguration
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<WeightAgeCategoryModel>, WeightAgeCategoryValidator>();
            services.AddTransient<IValidator<SuspensionTypeModel>, SuspensionTypeValidator>();
            services.AddTransient<IValidator<RoundModel>, RoundValidator>();
            services.AddTransient<IValidator<KhanLevelModel>, KhanLevelValidator>();
            services.AddTransient<IValidator<FightStructureModel>, FightStructureValidator>();
            services.AddTransient<IValidator<ContestTypeModel>, ContestTypeValidator>();
            services.AddTransient<IValidator<ContestRangeModel>, ContestRangeValidator>();
            services.AddTransient<IValidator<ContestPointsModel>, ContestPointsValidator>();
            services.AddTransient<IValidator<ContestCategoryModel>, ContestCategoryValidator>();
        }
    }
}