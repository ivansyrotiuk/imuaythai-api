using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IContestRequestsUploader
    {
        Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, int contestId,  Dictionary<int, int> contestCategoriesIdsDictionary, Dictionary<string, string> usersIdsDictionary);
    }
}