using FluentValidation;
using IMuaythai.Models.AccountModels;

namespace IMuaythai.Api.Validators.Account
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email can not be null");
            RuleFor(x => x.Password).NotNull().WithMessage("Password can not be null");
        }
    }
}
