using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Api.Users
{
    public class UserRolesManager
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
    }
}
