using FluentValidation;
using IMuaythai.Models.AccountModels;

namespace IMuaythai.Api.Validators.Account
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email can not be null");
            RuleFor(x => x.Password).NotNull().WithMessage("Password can not be null");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("The password and confirmation password do not match");
        }
    }
}
