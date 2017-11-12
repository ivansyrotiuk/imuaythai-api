using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Auth
{
    public class HttpUserContext : IHttpUserContext
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HttpUserContext(IHttpContextAccessor context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUser()
        {
            var userId = _context.HttpContext.User.GetUserId();
            return await _userManager.FindByIdAsync(userId);
        }

        public string GetUserId()
        {
            var userId = _context.HttpContext.User.GetUserId();
            return userId;
        }
    }
}