using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IUsersUploader
    {
        Dictionary<string, string> Upload(ApplicationDbContext context, ApplicationDbContext mainContext);
    }
}