using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class RoundsUploader: IDataUploader
    {
        private readonly IEqualityComparer<Round> _roundComparer;

        public RoundsUploader(IEqualityComparer<Round> roundComparer)
        {
            _roundComparer = roundComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext)
        {
            var localRounds = context.Rounds.ToList();
            var remoteRounds = mainContext.Rounds.ToList();
            var roundsIdsDictionary = localRounds.ToDictionary(c => c.Id, c => c.Id);

            foreach (var round in localRounds)
            {
                var remoteRound = remoteRounds.FirstOrDefault(r => r.Id == round.Id);
                if (remoteRound == null)
                {
                    var roundId = round.Id;
                    round.Id = 0;
                    mainContext.Rounds.Add(round);
                    mainContext.SaveChanges();

                    roundsIdsDictionary[roundId] = round.Id;
                    continue;
                }

                if (_roundComparer.Equals(round, remoteRound))
                {
                    continue;
                }

                round.DeepCopyTo(remoteRound);
            }

            mainContext.SaveChanges();

            return roundsIdsDictionary;
        }
    }
}