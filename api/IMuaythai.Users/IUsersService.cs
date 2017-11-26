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
        Task<IEnumerable<JudgeModel>> GetJudges();
        Task<IEnumerable<JudgeModel>> GetCoaches();
        Task<IEnumerable<JudgeModel>> GetDoctors();
        Task<UserModel> GetUser(string id);
        Task<UserModel> SaveUser(UserModel user);
        Task RemoveUser(UserModel user);
    }
}