using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class FightStructureUploader : IFightStructureUploader
    {
        private readonly IEqualityComparer<FightStructure> _fightStructureComparer;

        public FightStructureUploader(IEqualityComparer<FightStructure> fightStructureComparer)
        {
            _fightStructureComparer = fightStructureComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext,
            Dictionary<int, int> roundsIdsDictionary, Dictionary<int, int> weightAgeCategoriesIdsDictionary)
        {
            var localFightStructures = context.FightStructures.ToList();
            var remoteFightStructures = mainContext.FightStructures.ToList();
            var fightStructuresIdsDictionary = localFightStructures.ToDictionary(c => c.Id, c => c.Id);

            foreach (var fightStructure in localFightStructures)
            {
                fightStructure.RoundId = roundsIdsDictionary[fightStructure.RoundId];
                fightStructure.WeightAgeCategoryId =
                    weightAgeCategoriesIdsDictionary[fightStructure.WeightAgeCategoryId];

                var remoteFightStructure = remoteFightStructures.FirstOrDefault(r => r.Id == fightStructure.Id);
                if (remoteFightStructure == null)
                {
                    var fightStructureId = fightStructure.Id;
                    fightStructure.Id = 0;
                    mainContext.FightStructures.Add(fightStructure);
                    mainContext.SaveChanges();

                    fightStructuresIdsDictionary[fightStructureId] = fightStructure.Id;
                    continue;
                }

                if (_fightStructureComparer.Equals(fightStructure, remoteFightStructure))
                {
                    continue;
                }

                fightStructure.DeepCopyTo(remoteFightStructure);
            }

            mainContext.SaveChanges();


            return fightStructuresIdsDictionary;
        }
    }
}