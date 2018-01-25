using System;
using System.Threading.Tasks;
using IMuaythai.Auth;
using IMuaythai.Contests;
using IMuaythai.Models.Contests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Contests
{ 
    //[Authorize]
    [Route("api/[controller]")]
    public class ContestRequestsController : Controller
    {
        private readonly IContestRequestsService _requestsService;
        private readonly IHttpUserContext _httpUserContext;

        public ContestRequestsController(IContestRequestsService requestsService,
            IHttpUserContext httpUserContext)
        {
            _requestsService = requestsService;
            _httpUserContext = httpUserContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int contestId)
        {
            try
            {
                var requests = await _requestsService.GetRequests(contestId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("candidates")]
        [Authorize(Roles= "NationalFederation, WorldFederation, ContinentalFederation, GymAdmin, Admin, SuperAdmin")]
        public async Task<IActionResult> GetContestCandidates()
        {
            try
            {
                var user = await _httpUserContext.GetUser();

                if (user.InstitutionId == null)
                {
                    throw new Exception("No permissions. You are not assigned to any institution.");
                }

                var candidates = await _requestsService.GetCandidates(user.InstitutionId.Value);
                return Ok(candidates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("judges")]
        public async Task<IActionResult> GetContestJudgesRequests([FromQuery] int contestId)
        {
            try
            {
                var requests = await _requestsService.GetJudgeRequests(contestId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("myrequests")]
        public async Task<IActionResult> GetContestInstitutionRequests([FromQuery] int contestId)
        {
            try
            {
                var user = await _httpUserContext.GetUser();

                var requests = user.InstitutionId.HasValue ?
                    await _requestsService.GetInstitutionRequests(contestId, user.InstitutionId.Value) :
                    await _requestsService.GetUserRequests(contestId, user.Id);

                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveContestRequest([FromBody] ContestRequestModel requestModel)
        {
            try
            {
                var user = await _httpUserContext.GetUser();
                requestModel.InstitutionId = requestModel.InstitutionId ?? user.InstitutionId;
                var request = await _requestsService.SaveRequest(requestModel);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("accept")]
        public async Task<IActionResult> AcceptContestRequest([FromBody] ContestRequestModel requestModel)
        {
            try
            {
                var userId = _httpUserContext.GetUserId();
                var request = await _requestsService.AcceptRequest(requestModel.Id, userId);

                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("reject")]
        public async Task<IActionResult> RejectContestRequest([FromBody] ContestRequestModel requestModel)
        {
            try
            {
                var userId = _httpUserContext.GetUserId();
                var request = await _requestsService.RejectRequest(requestModel.Id, userId);

                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveContestRequest([FromBody] ContestRequestModel request)
        {
            try
            {
                await _requestsService.RemoveRequest(request.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("allocatejudge")]
        public async Task<IActionResult> AllocateJUdge([FromBody] ContestJudgeAllocationModel allocationModel)
        {
            try
            {
                var request = await _requestsService.AllocateJudge(allocationModel);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}