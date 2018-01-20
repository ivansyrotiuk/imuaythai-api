using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestCategoryMappingsUploader : IContestCategoryMappingsUploader
    {
        private readonly IEqualityComparer<ContestCategoriesMapping> _contestCategoryMappingComparer;

        public ContestCategoryMappingsUploader(
            IEqualityComparer<ContestCategoriesMapping> contestCategoryMappingComparer)
        {
            _contestCategoryMappingComparer = contestCategoryMappingComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext,
            Dictionary<int, int> contestIdsDictionary, Dictionary<int, int> contestCategoriesIdsDictionary)
        {
            var localMappings = context.ContestCategoriesMappings.ToList();
            var remoteMappings = mainContext.ContestCategoriesMappings.ToList();
            var mappingsIdsDictionary = localMappings.ToDictionary(c => c.Id, c => c.Id);
            localMappings.ForEach(mapping => mapping.NullReferencePropeties());
            remoteMappings.ForEach(mapping => mapping.NullReferencePropeties());

            bool needToSave = false;
            foreach (var mapping in localMappings)
            {
                mapping.ContestId = contestIdsDictionary[mapping.ContestId];
                mapping.ContestCategoryId = contestCategoriesIdsDictionary[mapping.ContestCategoryId];
                var remoteMapping = remoteMappings.FirstOrDefault(r => r.Id == mapping.Id);
                if (remoteMapping == null)
                {
                    var mappingId = mapping.Id;
                    mapping.Id = 0;
                    mainContext.ContestCategoriesMappings.Add(mapping);
                    mainContext.SaveChanges();
                    needToSave = false;
                    mappingsIdsDictionary[mappingId] = mapping.Id;
                    continue;
                }

                if (_contestCategoryMappingComparer.Equals(mapping, remoteMapping))
                {
                    continue;
                }

                remoteMapping.ContestId = mapping.ContestId;
                remoteMapping.ContestCategoryId = mapping.ContestCategoryId;
                needToSave = true;
            }

            if (needToSave)
                mainContext.SaveChanges();

            return mappingsIdsDictionary;
        }
    }
}