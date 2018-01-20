using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IFightJudgeMappingsUploader
    {
        Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, int contestId, Dictionary<int, int> fightsIdsDictionary, Dictionary<string, string> usersIdsDictionary);
    }
}