using FluentValidation;
using IMuaythai.Models.Institutions;

namespace IMuaythai.Api.Validators.Institutions
{
    public class InstitutionResponseValidator : AbstractValidator<InstitutionResponseModel>
    {
        public InstitutionResponseValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.CountryId).NotNull().WithMessage("CountryId can not be null");
            RuleFor(x => x.InstitutionType).NotNull().WithMessage("InstitutionType can not be null");
            RuleFor(x => x.MembersCount).NotNull().WithMessage("MembersCount can not be null");
            RuleFor(x => x.Address).Length(0, 500).WithMessage("Address is too long");
            RuleFor(x => x.City).Length(0, 500).WithMessage("City is too long");
            RuleFor(x => x.ContactPerson).Length(0, 500).WithMessage("ContactPerson is too long");
            RuleFor(x => x.Email).Length(0, 500).WithMessage("Email is too long");
            RuleFor(x => x.Facebook).Length(0, 500).WithMessage("Facebook is too long");
            RuleFor(x => x.HeadCoachId).Length(0, 450).WithMessage("HeadCoachId is too long");
            RuleFor(x => x.Instagram).Length(0, 500).WithMessage("Instagram is too long");
            RuleFor(x => x.Logo).Length(0, 500).WithMessage("Logo is too long");
            RuleFor(x => x.Name).Length(0, 500).WithMessage("Name is too long");
            RuleFor(x => x.Owner).Length(0, 500).WithMessage("Owner is too long");
            RuleFor(x => x.Phone).Length(0, 100).WithMessage("Phone is too long");
            RuleFor(x => x.Twitter).Length(0, 500).WithMessage("Twitter is too long");
            RuleFor(x => x.VK).Length(0, 500).WithMessage("VK is too long");
            RuleFor(x => x.Website).Length(0, 500).WithMessage("Website is too long");
        }
    }
}
