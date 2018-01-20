using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class ContestRequestsUploader : IContestRequestsUploader
    {
        private readonly IEqualityComparer<ContestRequest> _contestRequestComparer;

        public ContestRequestsUploader(IEqualityComparer<ContestRequest> contestRequestComparer)
        {
            _contestRequestComparer = contestRequestComparer;
        }

        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, int contestId,  Dictionary<int, int> contestCategoriesIdsDictionary, Dictionary<string, string> usersIdsDictionary)
        {
            var localRequests = context.ContestRequests.Where(request => request.ContestId == contestId).ToList();
            var remoteRequests =  mainContext.ContestRequests.Where(request => request.ContestId == contestId).ToList();
            var requestsIdsDictionary = localRequests.ToDictionary(c => c.Id, c => c.Id);
            localRequests.ForEach(request => request.NullReferencePropeties());
            remoteRequests.ForEach(request => request.NullReferencePropeties());
            var needToSave = false;
            foreach (var request in localRequests)
            {
                request.UserId = usersIdsDictionary[request.UserId];
                request.ContestCategoryId = request.ContestCategoryId.HasValue ? contestCategoriesIdsDictionary[request.ContestCategoryId.Value] : default(int?);
           
                var removeRequest = remoteRequests.FirstOrDefault(r => r.Id == request.Id);
                if (removeRequest == null)
                {
                    var requestId = request.Id;
                    request.Id = 0;
                    mainContext.ContestRequests.Add(request);
                     mainContext.SaveChanges();

                    requestsIdsDictionary[requestId] = request.Id;
                    continue;
                }

                if (_contestRequestComparer.Equals(request, removeRequest))
                {
                    continue;
                }

                needToSave = true;
                request.DeepCopyTo(removeRequest);
            }

            if (needToSave)
            {
                 mainContext.SaveChanges();
            }

            return requestsIdsDictionary;
        }
    }
}