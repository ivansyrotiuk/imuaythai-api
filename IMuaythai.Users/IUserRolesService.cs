using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Users;

namespace IMuaythai.Users
{
    public interface IUserRolesService
    {
        Task<IEnumerable<UserRoleRequestModel>> GetUserRoleRequests(string userId);
        Task<UserRoleRequestModel> AddUserRoleRequest(UserRoleRequestModel roleRequest);
        Task<IEnumerable<UserRoleRequestModel>> GetPendingRoleRequests();
        Task<UserRoleRequestModel> AcceptRoleRequest(UserRoleRequestModel roleRequest);
        Task<UserRoleRequestModel> RejectRoleRequest(UserRoleRequestModel roleRequest);
    }
}