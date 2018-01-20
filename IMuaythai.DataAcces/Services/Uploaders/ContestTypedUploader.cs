using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestTypedUploader : IDataUploader
    {
        private readonly IEqualityComparer<ContestType> _contestTypeComparer;

        public ContestTypedUploader(IEqualityComparer<ContestType> contestTypeComparer)
        {
            _contestTypeComparer = contestTypeComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext)
        {
            var localContestTypes = context.ContestTypes.ToList();
            var remoteContestTypes =  mainContext.ContestTypes.ToList();
            var contestTypesIdsDictionary = localContestTypes.ToDictionary(c => c.Id, c => c.Id);

            foreach (var localType in localContestTypes)
            {
                var remoteType = remoteContestTypes.FirstOrDefault(type => type.Id == localType.Id);
                if (remoteType == null)
                {
                    var typeId = localType.Id;
                    localType.Id = 0;
                    mainContext.ContestTypes.Add(localType);
                    mainContext.SaveChanges();

                    contestTypesIdsDictionary[typeId] = localType.Id;
                    continue;
                }

                if (_contestTypeComparer.Equals(localType, remoteType))
                {
                    continue;
                }

                localType.DeepCopyTo(remoteType);
            }

            mainContext.SaveChanges();

            return contestTypesIdsDictionary;
        }
    }
}