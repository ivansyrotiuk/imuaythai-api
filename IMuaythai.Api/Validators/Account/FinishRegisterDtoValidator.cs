using FluentValidation;
using IMuaythai.Models.AccountModels;

namespace IMuaythai.Api.Validators.Account
{
    public class FinishRegisterDtoValidator : AbstractValidator<FinishRegisterDto>
    {
        public FinishRegisterDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId can not be null");
            RuleFor(x => x.CountryId).NotNull().GreaterThan(0).WithMessage("CountryId can not be null");
            RuleFor(x => x.FirstName).NotNull().WithMessage("FirstName can not be null");
            RuleFor(x => x.GymName).NotNull().When(x => x.InstitutionId != null).WithMessage("GymName can not be null");
            RuleFor(x => x.Surname).NotNull().WithMessage("Surname can not be null");
            RuleFor(x => x.RoleId).NotNull().WithMessage("RoleId can not be null");
        }
    }
}
