using FluentValidation;
using IMuaythai.Fights;

namespace IMuaythai.Api.Validators.Fights
{
    public class FightMovingValidator : AbstractValidator<FightMoving>
    {
        public FightMovingValidator()
        {
            RuleFor(x => x.SourceFightId).NotNull().WithMessage("SourceFightId can not be null");
            RuleFor(x => x.TargetFightId).NotNull().WithMessage("TargetFightId can not be null");
        }
    }
}
