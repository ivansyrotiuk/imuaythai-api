using System;

namespace IMuaythai.Models.Users
{
    public class UserRoleRequestModel
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
    }

    public class CreateUserRoleRequestModel: UserRoleRequestModel
    {
       
    }

    public class UpdateUserRoleRequestModel : UserRoleRequestModel
    {
        
    }

    public class UserRoleRequestResponseModel : UserRoleRequestModel
    {

    }
}
