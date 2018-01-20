using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestsUploader : IContestsUploader
    {
        private readonly IEqualityComparer<Contest> _contestComparer;

        public ContestsUploader(IEqualityComparer<Contest> contestComparer)
        {
            _contestComparer = contestComparer;
        }

        public  Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, Dictionary<int, int> contestTypesIdsDictionary, Dictionary<int, int> contestRangesIdsDictionary)
        {
            var localContests =  context.Contests.ToList();
            localContests.ForEach(contest => contest.NullReferencePropeties());
            var remoteContests =  mainContext.Contests.ToList();
            remoteContests.ForEach(contest => contest.NullReferencePropeties());

            var contestsIdsDictionary = localContests.ToDictionary(c => c.Id, c => c.Id);

            foreach (var contest in localContests)
            {
                contest.ContestTypeId = contest.ContestTypeId.HasValue ? contestTypesIdsDictionary[contest.ContestTypeId.Value] : default(int?);
                contest.ContestRangeId = contest.ContestRangeId.HasValue ? contestRangesIdsDictionary[contest.ContestRangeId.Value] : default(int?);

                var remoteContest = remoteContests.FirstOrDefault(r => r.Id == contest.Id);
                if (remoteContest == null)
                {
                    var contestId = contest.Id;
                    contest.Id = 0;
                    mainContext.Contests.Add(contest);
                     mainContext.SaveChanges();

                    contestsIdsDictionary[contestId] = contest.Id;
                    continue;
                }

                if (_contestComparer.Equals(contest, remoteContest))
                {
                    continue;
                }

                contest.DeepCopyTo(remoteContest);
            }

             mainContext.SaveChanges();

            return contestsIdsDictionary;
        }
    }
}