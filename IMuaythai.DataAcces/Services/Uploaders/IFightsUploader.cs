using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IFightsUploader
    {
        Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, int contestId, Dictionary<string, string> usersIdsDictionary);
    }
}