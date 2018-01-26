using FluentValidation;
using IMuaythai.Fights;

namespace IMuaythai.Api.Validators.Fights
{
    public class FighterMovingValidator : AbstractValidator<FighterMoving>
    {
        public FighterMovingValidator()
        {
            RuleFor(x => x.SourceFightId).NotNull().WithMessage("SourceFightId can not be null");
            RuleFor(x => x.TargetFightId).NotNull().WithMessage("TargetFightId can not be null");
            RuleFor(x => x.SourceFighterId).NotNull().WithMessage("SourceFighterId can not be null");
            RuleFor(x => x.TargetFighterId).NotNull().WithMessage("TargetFighterId can not be null");
        }
    }
}
