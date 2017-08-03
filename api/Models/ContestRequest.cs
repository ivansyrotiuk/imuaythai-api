using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class ContestRequest
    {
        public int Id { get; set; }
        public ContestRoleType Type { get; set; }
        public DateTime IssueDate { get; set; }
        public ContestRoleRequestStatus Status { get; set; }
        public string UserId { get; set; }
        public int? InstitutionId { get; set; }
        public int ContestId { get; set; }
        public int? ContestCategoryId { get; set; }
        public string AcceptedByUserId { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public virtual ApplicationUser User { get; set; }     
        public virtual Institution Institution { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual ApplicationUser AcceptedByUser { get; set; }
        public virtual ContestCategory ContestCategory { get; set; }
    }

    public enum ContestRoleRequestStatus
    {
        Pending, Accepted, Rejected
    }

    public enum ContestRoleType
    {
        Fighter, Judge, Doctor, Coach
    }
}
