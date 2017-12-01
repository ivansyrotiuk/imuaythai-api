using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.Auth;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Users;
using IMuaythai.Repositories.Contests;

namespace IMuaythai.Contests
{
    public interface IContestsService
    {
        Task<IEnumerable<ContestModel>> GetContests();
        Task<ContestModel> GetContest(int id);
        Task<ContestModel> SaveContest(ContestModel contest);
        Task RemoveContest(int id);
        Task<IEnumerable<ContestCategoryWithFightersModel>> GetContestCategories(int contestId);
    }

    public class ContestsService : IContestsService
    {
        private readonly IContestRepository _repository;
        private readonly IContestRequestRepository _contestRequestsRepository;
        private readonly IContestCategoryMappingsRepository _contestCategoryMappingsRepository;
        private readonly IContestRingsRepository _contestRingsRepository;
        private readonly IMapper _mapper;
        private readonly IHttpUserContext _userContext;

        public ContestsService(IContestRepository repository,
            IContestRequestRepository contestRequestsRepository,
            IContestCategoryMappingsRepository contestCategoryMappingsRepository,
            IContestRingsRepository contestRingsRepository,
            IMapper mapper, IHttpUserContext userContext)
        {
            _repository = repository;
            _contestRequestsRepository = contestRequestsRepository;
            _contestCategoryMappingsRepository = contestCategoryMappingsRepository;
            _contestRingsRepository = contestRingsRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<IEnumerable<ContestModel>> GetContests()
        {
            var contests = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ContestModel>>(contests);
        }

        public async Task<ContestModel> GetContest(int id)
        {
            var contest = await _repository.Get(id);
            return _mapper.Map<ContestModel>(contest);
        }

        public async Task<ContestModel> SaveContest(ContestModel contest)
        {
            var user = await _userContext.GetUser() ?? throw new Exception("User not found");

            int institutionId = contest.InstitutionId == 0 && user.InstitutionId.HasValue ? user.InstitutionId.Value : contest.InstitutionId;

            Contest contestEntity = _mapper.Map<Contest>(contest);
            contestEntity.InstitutionId = institutionId;

            await _repository.Save(contestEntity);
            await _contestCategoryMappingsRepository.SaveCategoryMappings(contestEntity.Id, contest.ContestCategories);
            await _contestRingsRepository.SaveCategoryRings(contestEntity.Id, contest.Rings);

            return _mapper.Map<ContestModel>(contestEntity);
        }

        public async Task RemoveContest(int id)
        {
            await _repository.Remove(id);
        }

        public async Task<IEnumerable<ContestCategoryWithFightersModel>> GetContestCategories(int contestId)
        {
            var requests = await _contestRequestsRepository.GetContestAcceptedFighterRequests(contestId);
            var contestCategoriesWithFighters = requests.GroupBy(r => r.ContestCategory)
                .Select(g =>
                {
                    var contestCategory = _mapper.Map<ContestCategoryWithFightersModel>(g.Key);
                    var fighters = g.Select(request => request.User);
                    contestCategory.Fighters = _mapper.Map<List<FighterModel>>(fighters);
                    return contestCategory;
                }
              ).ToList();
            return contestCategoriesWithFighters;
        }
    }
}