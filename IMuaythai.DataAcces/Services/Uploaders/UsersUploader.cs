using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class UsersUploader : IUsersUploader
    {
        public Dictionary<string, string> Upload(ApplicationDbContext context, ApplicationDbContext mainContext)
        {
            var localUsers =  context.Users.ToList();
            var remoteUsers =  mainContext.Users.ToList();
            localUsers.ForEach(user => user.NullReferencePropeties());


            var usersIdsDictionary = localUsers.ToDictionary(c => c.Id, c => c.Id);

            foreach (var user in localUsers)
            {
                var remoteMapping = remoteUsers.FirstOrDefault(r => r.Id == user.Id);
                if (remoteMapping != null)
                {
                    continue;
                }

                user.FightJudgesMappings = null;
                mainContext.Users.Add(user);
            }

             mainContext.SaveChanges();

            return usersIdsDictionary;
        }
    }
}