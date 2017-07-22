using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Users
{
    public class UserRoleRequestDto
    {
        public int Id { get; set; } = 0;
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

        public UserRoleRequestDto(UserRoleRequest acceptation)
        {
            UserId = acceptation.UserId;
            UserName = acceptation.User?.UserName;
            RoleId = acceptation.RoleId;
            RoleName = acceptation.Role?.Name;
            AcceptationDate = acceptation.AcceptationDate;
            AcceptedByUserId = acceptation.AcceptedByUserId;
            AcceptedByUserName = acceptation.AcceptedByUser?.UserName;
            Status = Enum.GetName(typeof(UserRoleRequestStatus), acceptation.Status);
        }

        public static explicit operator UserRoleRequestDto(UserRoleRequest entity)
        {
            return new UserRoleRequestDto(entity);
        }
    }
}
