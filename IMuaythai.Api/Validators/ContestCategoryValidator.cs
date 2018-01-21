using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class ContestCategoryValidator : AbstractValidator<ContestCategoryModel>
    {
        public ContestCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.ContestTypePointsId).NotNull().WithMessage("ContestTypePointsId can not be null");
            RuleFor(x => x.FightStructureId).NotNull().WithMessage("FightStructureId can not be null");
            RuleFor(x => x.ServiceBreakDuration).NotNull().WithMessage("ServiceBreakDuration can not be null");
        }
    }
}
