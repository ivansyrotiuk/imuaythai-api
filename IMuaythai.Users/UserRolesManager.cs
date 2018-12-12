using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Users
{
    public interface IUserRolesManager
    {
        Task AddUserToRole(string userId, string roleName);
        Task RemoveUserFromRole(string userId, string roleName);
    }

    public class UserRolesManager : IUserRolesManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRolesManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddUserToRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveUserFromRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
