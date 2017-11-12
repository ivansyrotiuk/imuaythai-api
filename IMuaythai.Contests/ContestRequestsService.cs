using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using IMuaythai.Repositories.Contests;

namespace IMuaythai.Contests
{
    public class ContestRequestsService : IContestRequestsService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IContestRequestRepository _contestRequestsRepository;
        private readonly IMapper _mapper;

        public ContestRequestsService(IContestRequestRepository contestRequestsRepository,
            IUsersRepository userRepository,
            IMapper mapper)
        {
            _mapper = mapper;

            _userRepository = userRepository;
            _contestRequestsRepository = contestRequestsRepository;
        }

        public async Task<List<ContestRequestModel>> GetRequests(int contestId)
        {
            var requestEntities = await _contestRequestsRepository.GetByContest(contestId);
            return _mapper.Map<List<ContestRequest>, List<ContestRequestModel>>(requestEntities);
        }

        public async Task<List<ContestRequestModel>> GetJudgeRequests(int contestId)
        {
            var requestEntities = await _contestRequestsRepository.GetByContest(contestId, ContestRoleType.Judge);
            return _mapper.Map<List<ContestRequest>, List<ContestRequestModel>>(requestEntities);
        }

        public async Task<List<ContestRequestModel>> GetInstitutionRequests(int contestId, int institutionId)
        {
            var requestEntities = await _contestRequestsRepository.GetByInstitution(contestId, institutionId);
            return _mapper.Map<List<ContestRequest>, List<ContestRequestModel>>(requestEntities);
        }

        public async Task<List<ContestRequestModel>> GetUserRequests(int contestId, string userId)
        {
            var requestEntities = await _contestRequestsRepository.GetByUnassociatedUser(contestId, userId);
            return _mapper.Map<List<ContestRequest>, List<ContestRequestModel>>(requestEntities);
        }

        public async Task<ContestCandidatesModel> GetCandidates(int institutionId)
        {
            var institutionMembers = await _userRepository.GetInstitutionMembers(institutionId);

            ContestCandidatesModel candidates = new ContestCandidatesModel
            {
                DirectCandidates = _mapper.Map<List<ApplicationUser>, List<UserModel>>(institutionMembers)
            };

            return candidates;
        }

        public async Task<ContestRequestModel> AcceptRequest(int requestId, string acceptedByUser)
        {
            ContestRequest requestEntity = await _contestRequestsRepository.Get(requestId);
            if (requestEntity == null)
            {
                throw new Exception("Request not found");
            }

            requestEntity.Status = ContestRoleRequestStatus.Accepted;
            requestEntity.AcceptedByUserId = acceptedByUser;
            requestEntity.AcceptanceDate = DateTime.UtcNow;

            await _contestRequestsRepository.Save(requestEntity);
            return _mapper.Map<ContestRequest, ContestRequestModel>(requestEntity);
        }

        public async Task<ContestRequestModel> RejectRequest(int requestId, string acceptedByUser)
        {
            ContestRequest requestEntity = await _contestRequestsRepository.Get(requestId);
            if (requestEntity == null)
            {
                throw new Exception("Request not found");
            }

            requestEntity.Status = ContestRoleRequestStatus.Rejected;
            requestEntity.AcceptedByUserId = acceptedByUser;
            requestEntity.AcceptanceDate = DateTime.UtcNow;

            await _contestRequestsRepository.Save(requestEntity);
            return _mapper.Map<ContestRequest, ContestRequestModel>(requestEntity);
        }

        public async Task<ContestRequestModel> SaveRequest(ContestRequestModel request)
        {
            var existedRequests = await _contestRequestsRepository.Find(r => 
                r.Type != ContestRoleType.Judge && 
                r.UserId == request.UserId && 
                r.Type == request.Type && 
                r.ContestId == request.ContestId);

            if (existedRequests.Any())
            {
                throw new Exception("The same request is already added");
            }

            ContestRequest requestEntity = await _contestRequestsRepository.Get(request.Id) ?? new ContestRequest
                {
                    IssueDate = DateTime.UtcNow
                };

            requestEntity.ContestId = request.ContestId;
            requestEntity.ContestCategoryId = request.ContestCategoryId;
            requestEntity.InstitutionId = request.InstitutionId;
            requestEntity.Status = request.Status;
            requestEntity.Type = request.Type;
            requestEntity.UserId = request.UserId;

            await _contestRequestsRepository.Save(requestEntity);
            return _mapper.Map<ContestRequest, ContestRequestModel>(requestEntity);
        }

        public async Task RemoveRequest(int requestId)
        {
            ContestRequest requestEntity = await _contestRequestsRepository.Get(requestId);
            if (requestEntity == null)
            {
                throw new Exception("Request not found");
            }

            await _contestRequestsRepository.Remove(requestEntity);
        }
    }
}