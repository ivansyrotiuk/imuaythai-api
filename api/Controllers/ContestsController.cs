using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Contests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MuaythaiSportManagementSystemApi.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MuaythaiSportManagementSystemApi.Controllers
{ 
    [Authorize]
    [Route("api/[controller]")]
    public class ContestsController : Controller
    {
        private readonly IContestRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUsersRepository _userRepository;
        private readonly IContestRequestRepository _contestRequestsRepository;
        private readonly IContestCategoryMappingsRepository _contestCategoryMappingsRepository;
        private readonly IContestRingsRepository _contestRingsRepository;

        public ContestsController(IContestRepository repository,
            IContestRequestRepository contestRequestsRepository,
            IContestCategoryMappingsRepository contestCategoryMappingsRepository,
            IContestRingsRepository contestRingsRepository,
            IUsersRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
            _contestRequestsRepository = contestRequestsRepository;
            _contestCategoryMappingsRepository = contestCategoryMappingsRepository;
            _contestRingsRepository = contestRingsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var contestsEntities = await _repository.GetAll();
                var contests = contestsEntities.Select(c => (ContestDto)c).ToList();
                return Ok(contests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContest([FromRoute]int id)
        {
            try
            {
                var contestEntity = await _repository.Get(id);
                var contest = (ContestDto)contestEntity;
                return Ok(contest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveContest([FromBody]ContestDto contest)
        {
            try
            {
                var userId = User.GetUserId();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                int institutionId = contest.InstitutionId == 0 && user.InstitutionId.HasValue ? user.InstitutionId.Value : contest.InstitutionId;

                Contest contestEntity = contest.Id == 0 ? new Contest() : await _repository.Get(contest.Id);
                contestEntity.Id = contest.Id;
                contestEntity.Name = contest.Name;
                contestEntity.Date = contest.Date;
                contestEntity.Address = contest.Address;
                contestEntity.Duration = contest.Duration;
                contestEntity.RingsCount = contest.RingsCount;
                contestEntity.City = contest.City;
                contestEntity.CountryId = contest.CountryId;
                contestEntity.Website = contest.Website;
                contestEntity.Facebook = contest.Facebook;
                contestEntity.VK = contest.VK;
                contestEntity.Twitter = contest.Twitter;
                contestEntity.Instagram = contest.Instagram;
                contestEntity.WaiKhruTime = contest.WaiKhruTime;
                contestEntity.EndRegistrationDate = contest.EndRegistrationDate;
                contestEntity.ContestRangeId = contest.ContestRangeId;
                contestEntity.ContestTypeId = contest.ContestTypeId;
                contestEntity.InstitutionId = institutionId;
                await _repository.Save(contestEntity);
                await _contestCategoryMappingsRepository.SaveCategoryMappings(contestEntity.Id, contest.ContestCategories);
                await _contestRingsRepository.SaveCategoryRings(contestEntity.Id, contest.Rings);
                return Created("Add", contest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveContest([FromBody]ContestDto contest)
        {
            try
            {
                await _repository.Remove(contest.Id);

                return Ok(contest.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("candidates")]
        public async Task<IActionResult> GetContestCandidates()
        {
            try
            {
                var userId = User.GetUserId();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count == 0 ||
                    !roles.Contains("NationalFederation") && !roles.Contains("WorldFederation") &&
                    !roles.Contains("ContinentalFederation") && !roles.Contains("Gym") && !roles.Contains("Admin"))
                {
                    return BadRequest("No permissions");
                }

                if (user.InstitutionId == null)
                {
                    return BadRequest("No permissions. You are not assigned to any institution.");
                }

                ContestCandidatesDto candidates = new ContestCandidatesDto();
                var institutionMembers = await _userRepository.GetInstitutionMembers(user.InstitutionId.Value);
                candidates.DirectCandidates = institutionMembers.Select(u => (UserDto)u).ToList();

                return Ok(candidates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("requests")]
        public async Task<IActionResult> GetContestRequests([FromQuery] int contestId)
        {
            try
            {
                var requestEntities = await _contestRequestsRepository.GetByContest(contestId);

                var requests = requestEntities.Select(r => (ContestRequestDto)r).ToList();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("requests/institution")]
        public async Task<IActionResult> GetContestInstitutionRequests([FromQuery] int contestId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(User.GetUserId());
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                var requestEntities = user.InstitutionId.HasValue ?
                    await _contestRequestsRepository.GetByInstitution(contestId, user.InstitutionId.Value) :
                    await _contestRequestsRepository.GetByUnassociatedUser(contestId, user.Id);

                var requests = requestEntities.Select(r => (ContestRequestDto)r).ToList();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("requests/save")]
        public async Task<IActionResult> SaveContestRequest([FromBody] ContestRequestDto request)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return BadRequest("Cannot create request. User not found");
                }

                var existedRequests = await _contestRequestsRepository.Find(r => r.UserId == request.UserId && r.Type == request.Type && r.ContestId == request.ContestId);
                if (existedRequests.Count > 0)
                {
                    return BadRequest("The same request is already added");
                }

                ContestRequest requestEntity = request.Id == 0 ?
                        new ContestRequest() { IssueDate = DateTime.UtcNow } :
                        await _contestRequestsRepository.Get(request.Id);

                requestEntity.ContestId = request.ContestId;
                requestEntity.ContestCategoryId = request.ContestCategoryId;
                requestEntity.InstitutionId = request.InstitutionId ?? user.InstitutionId;
                requestEntity.Status = request.Status;
                requestEntity.Type = request.Type;
                requestEntity.UserId = request.UserId;

                await _contestRequestsRepository.Save(requestEntity);

                return Ok((ContestRequestDto)requestEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("requests/accept")]
        public async Task<IActionResult> AcceptContestRequest([FromBody] ContestRequestDto request)
        {
            try
            {
                var userId = User.GetUserId();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                ContestRequest requestEntity = await _contestRequestsRepository.Get(request.Id);
                if (requestEntity == null)
                {
                    return BadRequest("Request not found");
                }

                requestEntity.Status = ContestRoleRequestStatus.Accepted;
                requestEntity.AcceptedByUserId = userId;
                requestEntity.AcceptanceDate = DateTime.UtcNow;

                await _contestRequestsRepository.Save(requestEntity);

                return Ok((ContestRequestDto)requestEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("requests/reject")]
        public async Task<IActionResult> RejectContestRequest([FromBody] ContestRequestDto request)
        {
            try
            {
                var userId = User.GetUserId();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                ContestRequest requestEntity = await _contestRequestsRepository.Get(request.Id);
                if (requestEntity == null)
                {
                    return BadRequest("Request not found");
                }

                requestEntity.Status = ContestRoleRequestStatus.Rejected;
                requestEntity.AcceptedByUserId = userId;
                requestEntity.AcceptanceDate = DateTime.UtcNow;

                await _contestRequestsRepository.Save(requestEntity);

                return Ok((ContestRequestDto)requestEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("requests/remove")]
        public async Task<IActionResult> RemoveContestRequest([FromBody] ContestRequestDto request)
        {
            try
            {
                ContestRequest requestEntity = await _contestRequestsRepository.Get(request.Id);
                if (requestEntity == null)
                {
                    return BadRequest("Request not found");
                }

                await _contestRequestsRepository.Remove(requestEntity);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetContestCategoriesWithFighters([FromQuery] int contestId)
        {
            try
            {
                var requests = await _contestRequestsRepository.GetContestAcceptedFighterRequests(contestId);
                var fightersInCategories = requests.GroupBy(r => r.ContestCategory)
                    .Select(g => new ContestCategoryWithFightersDto(g.Key)
                    {
                        Fighters = g.Select(f => new FighterDto(f.User)).ToList()
                    }).ToList();

                return Ok(fightersInCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}