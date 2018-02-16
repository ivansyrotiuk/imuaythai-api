using FluentValidation;
using IMuaythai.Api.Validators;
using IMuaythai.Api.Validators.Account;
using IMuaythai.Api.Validators.Contest;
using IMuaythai.Api.Validators.Fights;
using IMuaythai.Api.Validators.Institutions;
using IMuaythai.Api.Validators.Locations;
using IMuaythai.Api.Validators.Roles;
using IMuaythai.Api.Validators.Users;
using IMuaythai.Fights;
using IMuaythai.Models.AccountModels;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Locations;
using IMuaythai.Models.Roles;
using IMuaythai.Models.Users;
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
            services.AddTransient<IValidator<UserModel>, UsersValidator>();
            services.AddTransient<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddTransient<IValidator<UserRoleRequestModel>, UserRoleRequestValidator>();
            services.AddTransient<IValidator<RoleModel>, RoleValidator>();
            services.AddTransient<IValidator<CountryModel>, CountryValidator>();
            services.AddTransient<IValidator<FightMoving>, FightMovingValidator>();
            services.AddTransient<IValidator<FighterMoving>, FighterMovingValidator>();
            services.AddTransient<IValidator<ContestRequestModel>, ContestRequestValidator>();
            services.AddTransient<IValidator<ContestResponseModel>, ContestResponseValidator>();
            services.AddTransient<IValidator<ContestUpdateModel>, ContestUpdateValidator>();
            services.AddTransient<IValidator<InstitutionUpdateModel>, InstitutionUpdateValidator>();
            services.AddTransient<IValidator<FinishRegisterDto>, FinishRegisterDtoValidator>();
            services.AddTransient<IValidator<ForgotPasswordDto>, ForgotPasswordDtoValidator>();
            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddTransient<IValidator<ResetPasswordDto>, ResetPasswordDtoValidator>();
            services.AddTransient<IValidator<VerifyCodeDto>, VerifyCodeDtoValidator>();
        }
    }
}