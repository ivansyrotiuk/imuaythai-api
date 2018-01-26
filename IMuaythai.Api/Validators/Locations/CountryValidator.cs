using FluentValidation;
using IMuaythai.Models.Locations;

namespace IMuaythai.Api.Validators.Locations
{
    public class CountryValidator : AbstractValidator<CountryModel>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
        }
    }
}
