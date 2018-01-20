using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class WeightAgeCategoryUploader:IDataUploader
    {
        private readonly IEqualityComparer<WeightAgeCategory> _weightAgeCategoryComparer;

        public WeightAgeCategoryUploader(IEqualityComparer<WeightAgeCategory> weightAgeCategoryComparer)
        {
            _weightAgeCategoryComparer = weightAgeCategoryComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext)
        {
            var localCategories = context.WeightAgeCategories.ToList();
            var remoteCategories = mainContext.WeightAgeCategories.ToList();
            var roundsIdsDictionary = localCategories.ToDictionary(c => c.Id, c => c.Id);

            foreach (var category in localCategories)
            {
                var remoteCategory = remoteCategories.FirstOrDefault(r => r.Id == category.Id);
                if (remoteCategory == null)
                {
                    var categoryId = category.Id;
                    category.Id = 0;
                    mainContext.WeightAgeCategories.Add(category);
                    mainContext.SaveChanges();

                    roundsIdsDictionary[categoryId] = category.Id;
                    continue;
                }

                if (_weightAgeCategoryComparer.Equals(category, remoteCategory))
                {
                    continue;
                }

                category.DeepCopyTo(remoteCategory);
            }

            mainContext.SaveChanges();

            return roundsIdsDictionary;
        }
    }
}