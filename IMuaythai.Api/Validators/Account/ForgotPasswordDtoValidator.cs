using FluentValidation;
using IMuaythai.Models.AccountModels;

namespace IMuaythai.Api.Validators.Account
{
    public class ForgotPasswordDtoValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email can not be null");
        }
    }
}
