using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Auth;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Users;
using IMuaythai.Repositories.Contests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Contests
{ 
    //[Authorize]
    [Route("api/[controller]")]
    public class ContestsController : Controller
    {
        private readonly IContestRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IContestRequestRepository _contestRequestsRepository;
        private readonly IContestCategoryMappingsRepository _contestCategoryMappingsRepository;
        private readonly IContestRingsRepository _contestRingsRepository;

        public ContestsController(IContestRepository repository,
            IContestRequestRepository contestRequestsRepository,
            IContestCategoryMappingsRepository contestCategoryMappingsRepository,
            IContestRingsRepository contestRingsRepository,
            UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
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
                var contests = contestsEntities.Select(c => (ContestModel)c).ToList();
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
                var contest = (ContestModel)contestEntity;
                return Ok(contest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveContest([FromBody]ContestModel contest)
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
        public async Task<IActionResult> RemoveContest([FromBody]ContestModel contest)
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
        [Route("categories")]
        public async Task<IActionResult> GetContestCategoriesWithFighters([FromQuery] int contestId)
        {
            try
            {
                var requests = await _contestRequestsRepository.GetContestAcceptedFighterRequests(contestId);
                var fightersInCategories = requests.GroupBy(r => r.ContestCategory)
                    .Select(g => new ContestCategoryWithFightersModel(g.Key)
                    {
                        Fighters = g.Select(f => new FighterModel(f.User)).ToList()
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