using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IFightStructureUploader
    {
        Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext,
            Dictionary<int, int> roundsIdsDictionary, Dictionary<int, int> weightAgeCategoriesIdsDictionary);
    }
}