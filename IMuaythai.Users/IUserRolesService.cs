using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Users;

namespace IMuaythai.Users
{
    public interface IUserRolesService
    {
        Task<IEnumerable<UserRoleRequestResponseModel>> GetUserRoleRequests(string userId);
        Task<UserRoleRequestResponseModel> AddUserRoleRequest(CreateUserRoleRequestModel roleRequest);
        Task<IEnumerable<UserRoleRequestResponseModel>> GetPendingRoleRequests();
        Task<UserRoleRequestResponseModel> AcceptRoleRequest(UpdateUserRoleRequestModel roleRequest);
        Task<UserRoleRequestResponseModel> RejectRoleRequest(UpdateUserRoleRequestModel roleRequest);
    }
}