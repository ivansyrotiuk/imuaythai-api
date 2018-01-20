using System.Collections.Generic;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public interface IFightPointsUploader
    {
        void Upload(ApplicationDbContext context, ApplicationDbContext mainContext, Dictionary<int, int> fightsIdsDictionary, Dictionary<string, string> usersIdsDictionary);
    }
}