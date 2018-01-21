using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class ContestRangeValidator : AbstractValidator<ContestRangeModel>
    {
        public ContestRangeValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.Name).Length(0, 500).WithMessage("Name is too long");
        }
    }
}
