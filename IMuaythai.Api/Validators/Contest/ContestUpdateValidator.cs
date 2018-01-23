using FluentValidation;
using IMuaythai.Models.Contests;

namespace IMuaythai.Api.Validators.Contest
{
    public class ContestUpdateValidator : AbstractValidator<ContestUpdateModel>
    {
        public ContestUpdateValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.Address).NotNull().WithMessage("Address can not be null");
            RuleFor(x => x.AllowUnassociated).NotNull().WithMessage("AllowUnassociated can not be null");
            RuleFor(x => x.City).NotNull().WithMessage("City can not be null");
            RuleFor(x => x.CountryId).NotNull().WithMessage("CountryId can not be null");
            RuleFor(x => x.Date).NotNull().WithMessage("Date can not be null");
            RuleFor(x => x.Duration).NotNull().WithMessage("Duration can not be null");
            RuleFor(x => x.EndRegistrationDate).NotNull().WithMessage("EndRegistrationDate can not be null");
            RuleFor(x => x.Name).NotNull().WithMessage("Name can not be null");
            RuleFor(x => x.RingsCount).NotNull().WithMessage("RingsCount can not be null");
            RuleFor(x => x.WaiKhruTime).NotNull().WithMessage("WaiKhruTime can not be null");
            RuleFor(x => x.Address).Length(0, 500).WithMessage("Address is too long");
            RuleFor(x => x.City).Length(0, 500).WithMessage("City is too long");
            RuleFor(x => x.Facebook).Length(0, 500).WithMessage("Facebook is too long");
            RuleFor(x => x.Instagram).Length(0, 500).WithMessage("Instagram is too long");
            RuleFor(x => x.Name).Length(0, 500).WithMessage("Name is too long");
            RuleFor(x => x.Twitter).Length(0, 500).WithMessage("Twitter is too long");
            RuleFor(x => x.VK).Length(0, 500).WithMessage("VK is too long");
            RuleFor(x => x.Website).Length(0, 500).WithMessage("Website is too long");
        }
    }
}
