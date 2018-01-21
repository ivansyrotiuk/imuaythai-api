using FluentValidation;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Api.Validators
{
    public class SuspensionTypeValidator : AbstractValidator<SuspensionTypeModel>
    {
        public SuspensionTypeValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
        }
    }
}
