using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class UserRoleRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public DateTime? AcceptationDate { get; set; }
        public string AcceptedByUserId { get; set; }
        public UserRoleRequestStatus Status { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser AcceptedByUser { get; set; }
        public virtual IdentityRole Role { get; set; }
    }

    public enum UserRoleRequestStatus
    {
        Pending, Accepted, Rejected
    }
}
