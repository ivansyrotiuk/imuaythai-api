using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class FightStructureValidator : AbstractValidator<FightStructureModel>
    {
        public FightStructureValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.RoundId).NotNull().WithMessage("RoundId can not be null");
            RuleFor(x => x.WeightAgeCategoryId).NotNull().WithMessage("WeightAgeCategoryId can not be null");
        }
    }
}
