using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestTypePointsUploader : IContestTypePointsUploader
    {
        private readonly IEqualityComparer<ContestTypePoints> _contestTypePointsComparer;

        public ContestTypePointsUploader(IEqualityComparer<ContestTypePoints> contestTypePointsComparer)
        {
            _contestTypePointsComparer = contestTypePointsComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, Dictionary<int, int> contestTypesIdsDictionary, 
            Dictionary<int, int> contestRangesIdsDictionary)
        {
            var localContestTypePoints = context.ContestTypePoints.ToList();
            var remoteContestTypePoints = mainContext.ContestTypePoints.ToList();
            var contestTypePointsIdsDictionary = localContestTypePoints.ToDictionary(c => c.Id, c => c.Id);

            foreach (var contestPoints in localContestTypePoints)
            {
                contestPoints.ContestTypeId = contestTypesIdsDictionary[contestPoints.ContestTypeId];
                contestPoints.ContestRangeId = contestRangesIdsDictionary[contestPoints.ContestRangeId];

                var remoteRange = remoteContestTypePoints.FirstOrDefault(points => points.Id == contestPoints.Id);
                if (remoteRange == null)
                {
                    var pointsId = contestPoints.Id;
                    contestPoints.Id = 0;
                    mainContext.ContestTypePoints.Add(contestPoints);
                    mainContext.SaveChanges();

                    contestTypePointsIdsDictionary[pointsId] = contestPoints.Id;
                    continue;
                }

                if (_contestTypePointsComparer.Equals(contestPoints, remoteRange))
                {
                    continue;
                }

                contestPoints.DeepCopyTo(remoteRange);
            }

            mainContext.SaveChanges();

            return contestTypePointsIdsDictionary;
        }
    }
}