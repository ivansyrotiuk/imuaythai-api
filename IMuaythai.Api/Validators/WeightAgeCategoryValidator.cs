using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class WeightAgeCategoryValidator : AbstractValidator<WeightAgeCategoryModel>
    {
        public WeightAgeCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.MinWeight).NotNull().WithMessage("MinWeight can not be null");
            RuleFor(x => x.MaxWeight).NotNull().WithMessage("MaxWeight can not be null");
            RuleFor(x => x.MaxWeight).GreaterThanOrEqualTo(x => x.MinWeight).WithMessage("MaxWeight can not be less than MinWeight");
            RuleFor(x => x.MinAge).NotNull().WithMessage("MinAge can not be null");
            RuleFor(x => x.MaxAge).NotNull().WithMessage("MaxAge can not be null");
            RuleFor(x => x.MaxAge).GreaterThanOrEqualTo(x => x.MinAge).WithMessage("MaxAge can not be less than MinAge");
        }
    }
}