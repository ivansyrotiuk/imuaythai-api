using System;
using System.Threading.Tasks;
using IMuaythai.Models.Users;
using IMuaythai.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Authorize]
    [Route("api/users/roles")]
    public class UserRolesController : Controller
    {
        private readonly IUserRolesService _userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserRoles([FromRoute]string userId)
        {
            try
            {
                var userRoleRequests = await _userRolesService.GetUserRoleRequests(userId);
                return Ok(userRoleRequests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("requests")]
        public async Task<IActionResult> GetRoleRequest()
        {
            try
            {
                var pendingRequest = await _userRolesService.GetPendingRoleRequests();
                return Ok(pendingRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addrequest")]
        public async Task<IActionResult> AddUserRoleRequest([FromBody] UserRoleRequestModel roleRequestModel)
        {
            try
            {
                var roleRequest = await _userRolesService.AddUserRoleRequest(roleRequestModel);
                return Ok(roleRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("acceptrequest")]
        public async Task<IActionResult> AcceptRoleRequest([FromBody] UserRoleRequestModel roleRequestModel)
        {
            try
            {
                var roleRequest = await _userRolesService.AcceptRoleRequest(roleRequestModel);
                return Ok(roleRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("rejectrequest")]
        public async Task<IActionResult> RejectRoleRequest([FromBody] UserRoleRequestModel roleRequestModel)
        {
            try
            {
                var roleRequest = await _userRolesService.RejectRoleRequest(roleRequestModel);
                return Ok(roleRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}