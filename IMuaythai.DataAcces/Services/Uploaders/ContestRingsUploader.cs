using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestRingsUploader : IContestRingsUploader
    {
        private readonly IEqualityComparer<ContestRing> _contestRingComparer;

        public ContestRingsUploader(IEqualityComparer<ContestRing> contestRingComparer)
        {
            _contestRingComparer = contestRingComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext,
            Dictionary<int, int> contestIdsDictionary)
        {
            var localRings = context.ContestRings.ToList();
            var remoteRings = mainContext.ContestRings.ToList();
            var ringsIdsDictionary = localRings.ToDictionary(c => c.Id, c => c.Id);
            localRings.ForEach(ring => ring.NullReferencePropeties());
            remoteRings.ForEach(ring => ring.NullReferencePropeties());

            var needToSave = false;
            foreach (var ring in localRings)
            {
                ring.ContestId = contestIdsDictionary[ring.ContestId];

                var remoteRing = remoteRings.FirstOrDefault(r => r.Id == ring.Id);
                if (remoteRing == null)
                {
                    var ringId = ring.Id;
                    ring.Id = 0;
                    mainContext.ContestRings.Add(ring);

                    mainContext.SaveChanges();
                    needToSave = false;
                    ringsIdsDictionary[ringId] = ring.Id;
                    continue;
                }

                if (_contestRingComparer.Equals(ring, remoteRing))
                {
                    continue;
                }

                needToSave = true;
                ring.DeepCopyTo(remoteRing);
            }

            if (needToSave)
            {
                mainContext.SaveChanges();
            }

            return ringsIdsDictionary;
        }
    }
}