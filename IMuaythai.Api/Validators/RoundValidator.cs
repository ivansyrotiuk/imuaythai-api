using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class RoundValidator : AbstractValidator<RoundModel>
    {
        public RoundValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.Duration).NotNull().GreaterThan(0).WithMessage("Duration can not be null");
            RuleFor(x => x.RoundsCount).NotNull().GreaterThan(0).WithMessage("RoundsCount can not be null");
            RuleFor(x => x.BreakDuration).NotNull().WithMessage("BreakDuration can not be null");
        }
    }
}
