using FluentValidation;
using IMuaythai.Models.AccountModels;

namespace IMuaythai.Api.Validators.Account
{
    public class VerifyCodeDtoValidator : AbstractValidator<VerifyCodeDto>
    {
        public VerifyCodeDtoValidator()
        {
            RuleFor(x => x.Provider).NotNull().WithMessage("Provider can not be null");
            RuleFor(x => x.Code).NotNull().WithMessage("Code can not be null");
        }
    }
}
