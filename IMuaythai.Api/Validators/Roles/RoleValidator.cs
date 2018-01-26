using FluentValidation;
using IMuaythai.Models.Roles;

namespace IMuaythai.Api.Validators.Roles
{
    public class RoleValidator : AbstractValidator<RoleModel>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.Id).Length(0, 450).WithMessage("Id is too long");
            RuleFor(x => x.Name).Length(0, 256).WithMessage("Name is too long");
            RuleFor(x => x.NormalizedName).Length(0, 256).WithMessage("NormalizedName is too long");
        }
    }
}
