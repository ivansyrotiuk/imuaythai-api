using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class ContestPointsValidator : AbstractValidator<ContestPointsModel>
    {
        public ContestPointsValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.ContestRangeId).NotNull().WithMessage("ContestRangeId can not be null");
            RuleFor(x => x.ContestTypeId).NotNull().WithMessage("ContestTypeId can not be null");
            RuleFor(x => x.Points).NotNull().WithMessage("Points can not be null");
        }
    }
}
