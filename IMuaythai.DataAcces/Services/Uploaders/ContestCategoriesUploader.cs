using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestCategoriesUploader : IContestCategoriesUploader
    {
        private readonly IEqualityComparer<ContestCategory> _contestCategoriesComparer;

        public ContestCategoriesUploader(IEqualityComparer<ContestCategory> contestCategoriesComparer)
        {
            _contestCategoriesComparer = contestCategoriesComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, Dictionary<int, int> contestTypePointsDictionary, Dictionary<int, int> fightStructuresIdsDictionary)
        {
            var localCategories = context.ContestCategories.ToList();
            var remoteCategories =  mainContext.ContestCategories.Take(100).ToList();
            var categorieIdsDictionary = localCategories.ToDictionary(c => c.Id, c => c.Id);
            localCategories.ForEach(category => category.NullReferencePropeties());
          
            var needToSave = false;
            foreach (var category in localCategories)
            {
                category.ContestTypePointsId = contestTypePointsDictionary[category.ContestTypePointsId];
                category.FightStructureId = fightStructuresIdsDictionary[category.FightStructureId];

                var remoteCategory = remoteCategories.FirstOrDefault(r => r.Id == category.Id);
                if (remoteCategory == null)
                {
                    var categoryId = category.Id;
                    category.Id = 0;
                    mainContext.ContestCategories.Add(category);
                     mainContext.SaveChanges();

                    categorieIdsDictionary[categoryId] = category.Id;
                    continue;
                }

                if (_contestCategoriesComparer.Equals(category, remoteCategory))
                {
                    continue;
                }

                needToSave = true;
                category.DeepCopyTo(remoteCategory);
            }

            if (needToSave)
            {
                 mainContext.SaveChanges();
            }

            return categorieIdsDictionary;

        }
    }
}