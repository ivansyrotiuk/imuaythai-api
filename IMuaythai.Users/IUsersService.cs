using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;

namespace IMuaythai.Users
{
    public interface IUsersService
    {
        Task<ApplicationUser> CreateUser(CreateUserModel createUserModel);
    }
}