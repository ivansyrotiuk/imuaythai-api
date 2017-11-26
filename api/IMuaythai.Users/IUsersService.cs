using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;

namespace IMuaythai.Users
{
    public interface IUsersService
    {
        Task<ApplicationUser> CreateUser(CreateUserModel createUserModel);
        Task<IEnumerable<FighterModel>> GetFigthers();
        Task<IEnumerable<FighterModel>> GetJudges();
        Task<IEnumerable<FighterModel>> GetCoaches();
        Task<IEnumerable<FighterModel>> GetDoctors();
        Task<FighterModel> GetUser(string id);
        Task<FighterModel> SaveUser(UserModel user);
        Task RemoveUser(UserModel user);
    }

    public interface IUserRolesService
    {
        Task<IEnumerable<UserRoleRequestModel>> GetUserRoles(string userId);
        Task<UserRoleRequestModel> AddUserRoleRequest(UserRoleRequestModel roleRequest);
        Task<IEnumerable<UserRoleRequestModel>> GetRoleRequest();
        Task<UserRoleRequestModel> AcceptRoleRequest(UserRoleRequestModel roleRequest);
        Task<UserRoleRequestModel> RejectRoleRequest(UserRoleRequestModel roleRequest);
    }
}