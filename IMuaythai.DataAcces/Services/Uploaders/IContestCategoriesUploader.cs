using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IContestCategoriesUploader
    {
        Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, Dictionary<int, int> contestTypePointsDictionary, Dictionary<int, int> fightStructuresIdsDictionary);
    }
}