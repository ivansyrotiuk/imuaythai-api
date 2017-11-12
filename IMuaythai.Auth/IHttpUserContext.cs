using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Auth
{
    public interface IHttpUserContext
    {
        Task<ApplicationUser> GetUser();
        string GetUserId();
    }
}