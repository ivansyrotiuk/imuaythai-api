using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IContestsUploader
    {
        Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, Dictionary<int, int> contestTypesIdsDictionary, Dictionary<int, int> contestRangesIdsDictionary);
    }
}