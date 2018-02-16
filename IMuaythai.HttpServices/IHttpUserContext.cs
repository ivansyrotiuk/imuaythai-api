using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace IMuaythai.HttpServices
{
    public interface IHttpUserContext
    {
        Task<ApplicationUser> GetUser();
        string GetUserId();
        HttpContext GetHttpContext();
    }
}