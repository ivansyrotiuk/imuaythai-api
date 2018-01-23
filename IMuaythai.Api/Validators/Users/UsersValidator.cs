using FluentValidation;
using IMuaythai.Models.Users;

namespace IMuaythai.Api.Validators.Users
{
    public class UsersValidator : AbstractValidator<UserModel>
    {
        public UsersValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.Accepted).NotNull().WithMessage("Accepted can not be null");
            RuleFor(x => x.Birthdate).NotNull().WithMessage("Birthdate can not be null");
            RuleFor(x => x.Type).NotNull().WithMessage("Type can not be null");
            RuleFor(x => x.Id).Length(0, 450).WithMessage("Id is too long");
            RuleFor(x => x.CoachLevel).Length(0,100).WithMessage("CoachLevel is too long");
            RuleFor(x => x.Email).Length(0, 256).WithMessage("Email is too long");
            RuleFor(x => x.Facebook).Length(0, 500).WithMessage("Facebook is too long");
            RuleFor(x => x.Firstname).Length(0, 500).WithMessage("Firstname is too long");
            RuleFor(x => x.Gender).Length(0, 10).WithMessage("Gender is too long");
            RuleFor(x => x.Instagram).Length(0, 500).WithMessage("Instagram is too long");
            RuleFor(x => x.Nationality).Length(0, 500).WithMessage("Nationality is too long");
            RuleFor(x => x.Phone).Length(0, 60).WithMessage("Phone is too long");
            RuleFor(x => x.Photo).Length(0, 1000).WithMessage("Photo is too long");
            RuleFor(x => x.Surname).Length(0, 500).WithMessage("Surname is too long");
            RuleFor(x => x.Twitter).Length(0, 500).WithMessage("Twitter is too long");
            RuleFor(x => x.VK).Length(0, 500).WithMessage("VK is too long");
        }
    }
}
