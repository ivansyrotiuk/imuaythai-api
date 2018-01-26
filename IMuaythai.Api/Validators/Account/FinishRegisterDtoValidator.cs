using FluentValidation;
using IMuaythai.Models.AccountModels;

namespace IMuaythai.Api.Validators.Account
{
    public class FinishRegisterDtoValidator : AbstractValidator<FinishRegisterDto>
    {
        public FinishRegisterDtoValidator()
        {
            //Dont know what should be checked here
            //RuleFor(x => x.UserId).NotNull().WithMessage("UserId can not be null");
            //RuleFor(x => x.CountryId).NotNull().WithMessage("CountryId can not be null");
            //RuleFor(x => x.FirstName).NotNull().WithMessage("FirstName can not be null");
            //RuleFor(x => x.GymName).NotNull().WithMessage("GymName can not be null");
            //RuleFor(x => x.InstitutionId).NotNull().WithMessage("InstitutionId can not be null");
            //RuleFor(x => x.Surname).NotNull().WithMessage("Surname can not be null");
            //RuleFor(x => x.RoleId).NotNull().WithMessage("RoleId can not be null");
            //RuleFor(x => x.OwnGym).NotNull().WithMessage("OwnGym can not be null");
        }
    }
}
