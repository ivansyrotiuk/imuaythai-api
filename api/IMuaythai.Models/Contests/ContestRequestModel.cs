using System;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;

namespace IMuaythai.Models.Contests
{
    public class ContestRequestModel
    {
        public int Id { get; set; }
        public ContestRoleType Type { get; set; }
        public ContestJudgeType? JudgeType { get; set; }
        public DateTime IssueDate { get; set; }
        public ContestRoleRequestStatus Status { get; set; }
        public string UserId { get; set; }
        public int? InstitutionId { get; set; }
        public int ContestId { get; set; }
        public int? ContestCategoryId { get; set; }
        public string AcceptedByUserId { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public string UserName { get; set; }
        public string InstitutionName { get; set; }
        public string ContestName { get; set; }
        public string ContestCategoryName { get; set; }
        public string AcceptedByUserName { get; set; }
        public UserModel User { get; set; }

        public ContestRequestModel()
        {

        }

        public ContestRequestModel(ContestRequest request)
        {
            Id = request.Id;
            Type = request.Type;
            JudgeType = request.JudgeType;
            IssueDate = request.IssueDate;
            Status = request.Status;
            UserId = request.UserId;
            InstitutionId = request.InstitutionId;
            ContestId = request.ContestId;
            ContestCategoryId = request.ContestCategoryId;
            AcceptedByUserId = request.AcceptedByUserId;
            AcceptanceDate = request.AcceptanceDate;
            UserName = request.User?.FirstName + ' ' + request.User?.Surname;
            InstitutionName = request.Institution?.Name;
            ContestName = request.Contest?.Name;
            ContestCategoryName = request.ContestCategory?.Name;
            AcceptedByUserName = request.AcceptedByUser?.FirstName + ' ' + request.AcceptedByUser?.Surname;
            User = (UserModel)request.User;
        }

        public static explicit operator ContestRequestModel(ContestRequest request)
        {
            return new ContestRequestModel(request);
        }
    }
}
