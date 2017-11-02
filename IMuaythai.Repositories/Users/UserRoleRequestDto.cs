using System;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Users
{
    public class UserRoleRequestDto
    {
        public int Id { get; set; } = 0;
        public int? InstitutionId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime? AcceptationDate { get; set; }
        public string AcceptedByUserId { get; set; }
        public string AcceptedByUserName { get; set; }
        public string Status { get; set; }

        public UserRoleRequestDto()
        {

        }

        public UserRoleRequestDto(UserRoleRequest request)
        {
            Id = request.Id;
            UserId = request.UserId;
            UserName = request.User?.UserName;
            RoleId = request.RoleId;
            RoleName = request.Role?.Name;
            AcceptationDate = request.AcceptationDate;
            AcceptedByUserId = request.AcceptedByUserId;
            AcceptedByUserName = request.AcceptedByUser?.UserName;
            Status = Enum.GetName(typeof(UserRoleRequestStatus), request.Status);
        }

        public static explicit operator UserRoleRequestDto(UserRoleRequest entity)
        {
            return new UserRoleRequestDto(entity);
        }
    }
}
