using IMuaythai.DataAccess.Models;

namespace IMuaythai.Users
{
    public static class ApplicationUserExtensions
    {
        public static string GetFullName(this ApplicationUser user)
        {
            return user == null ? null : $"{user.FirstName} {user.Surname}";
        }
    }
}
