using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class RoundDeleteModelValidator : AbstractValidator<RoundDeleteModel>
    {
        public RoundDeleteModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be grather than 0");
            
        }
    }
}