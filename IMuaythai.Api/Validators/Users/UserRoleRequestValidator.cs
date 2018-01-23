using FluentValidation;
using IMuaythai.Models.Users;

namespace IMuaythai.Api.Validators.Users
{
    public class UserRoleRequestValidator : AbstractValidator<UserRoleRequestModel>
    {
        public UserRoleRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.Status).NotNull().WithMessage("Status can not be null");
            RuleFor(x => x.AcceptedByUserId).Length(0,450).WithMessage("AcceptedByUserId is too long");
            RuleFor(x => x.RoleId).Length(0,450).WithMessage("RoleId is too long");
            RuleFor(x => x.UserId).Length(0,450).WithMessage("UserId is too long");
        }
    }
}
