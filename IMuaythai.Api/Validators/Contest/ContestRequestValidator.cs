using FluentValidation;
using IMuaythai.Models.Contests;

namespace IMuaythai.Api.Validators.Contest
{
    public class ContestRequestValidator : AbstractValidator<ContestRequestModel>
    {
        public ContestRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.AcceptanceDate).NotNull().WithMessage("AcceptanceDate can not be null");
            RuleFor(x => x.ContestId).NotNull().WithMessage("ContestId can not be null");
            RuleFor(x => x.IssueDate).NotNull().WithMessage("IssueDate can not be null");
            RuleFor(x => x.Status).NotNull().WithMessage("Status can not be null");
            RuleFor(x => x.Type).NotNull().WithMessage("Type can not be null");
            RuleFor(x => x.AcceptedByUserId).Length(0, 450).WithMessage("AcceptedByUserId is too long");
            RuleFor(x => x.UserId).Length(0, 450).WithMessage("UserId is too long");
        }
    }
}
