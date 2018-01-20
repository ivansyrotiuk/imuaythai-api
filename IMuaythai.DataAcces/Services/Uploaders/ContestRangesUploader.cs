using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestRangesUploader : IDataUploader
    {
        private readonly IEqualityComparer<ContestRange> _contestRangeComparer;

        public ContestRangesUploader(IEqualityComparer<ContestRange> contestRangeComparer)
        {
            _contestRangeComparer = contestRangeComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext)
        {
            var localContestRanges = context.ContestRanges.ToList();
            var remoteContestRanges  = mainContext.ContestRanges.ToList();
            var contestRangesIdsDictionary = localContestRanges.ToDictionary(c => c.Id, c => c.Id);

            foreach (var contestRange in localContestRanges)
            {
                var remoteRange = remoteContestRanges.FirstOrDefault(range => range.Id == contestRange.Id);
                if (remoteRange == null)
                {
                    var rangeId = contestRange.Id;
                    contestRange.Id = 0;
                    mainContext.ContestRanges.Add(contestRange);
                    mainContext.SaveChanges();

                    contestRangesIdsDictionary[rangeId] = contestRange.Id;
                    continue;
                }

                if (_contestRangeComparer.Equals(contestRange, remoteRange))
                {
                    continue;
                }

                contestRange.DeepCopyTo(remoteRange);
            }

            mainContext.SaveChanges();

            return contestRangesIdsDictionary;
        }
    }
}