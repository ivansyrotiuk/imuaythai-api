using System;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using System.Linq;
using MuaythaiSportManagementSystemApi.Users;
using MuaythaiSportManagementSystemApi.Models;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Roles;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private IUsersRepository _repository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IUserRoleRequestsRepository _userRoleRequestsRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IUsersRepository repository, 
            IRolesRepository rolesRepository,
            IUserRoleRequestsRepository userRoleAcceptationsRepository,
            UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _rolesRepository = rolesRepository;
            _userRoleRequestsRepository = userRoleAcceptationsRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("fighters")]
        public async Task<IActionResult> GetFigthers()
        {
            try
            {
                IUsersRepository fightersRepository = new FightersRepository(_repository);
                var figtherEntities = await fightersRepository.GetAll();
                var users = figtherEntities.Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFigthers([FromRoute]string id)
        {
            try
            {
                IUsersRepository fightersRepository = new FightersRepository(_repository);
                var figther = await fightersRepository.Get(id);
                var figtherRoles = await _userManager.GetRolesAsync(figther);
                var user = (FighterDto)figther;
                user.Roles = figtherRoles.ToList();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Judges")]
        public async Task<IActionResult> GetJudges()
        {
            try
            {
                var judgeEntities = await _repository.GetAll();
                var users = judgeEntities.Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Coaches")]
        public async Task<IActionResult> GetCoaches()
        {
            try
            {
                var coachEntities = await _repository.GetAll();
                var users = coachEntities.Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var doctorEntities = await _repository.GetAll();
                var users = doctorEntities.Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveUser([FromBody]UserDto user)
        {
            try
            {
                ApplicationUser userEntity = string.IsNullOrEmpty(user.Id) ? new ApplicationUser() : await _repository.Get(user.Id);
                userEntity.Id = user.Id;
                userEntity.FirstName = user.Firstname;
                userEntity.Surname = user.Surname;
                userEntity.Birthdate = user.Birthdate;
                userEntity.Nationality = user.Nationality;
                userEntity.Facebook = user.Facebook;
                userEntity.Instagram = user.Instagram;
                userEntity.Twitter = user.Twitter;
                userEntity.VK = user.VK;
                userEntity.Phone = user.Phone;
                userEntity.Gender = user.Gender;
                userEntity.CountryId = user.CountryId;

                await _repository.Save(userEntity);

                user.Id = userEntity.Id;

                return Created("Add", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Remove")]
        public IActionResult RemoveUser([FromBody]UserDto user)
        {
            try
            {
                _repository.Remove(user.Id);

                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("roles/{userId}")]
        public async Task<IActionResult> GetUserRoles([FromRoute]string userId)
        {
            try
            {
                var userRoleAcceptationEntities = await _userRoleRequestsRepository.GetUserRequests(userId);
                var userRoleAcceptations = userRoleAcceptationEntities.Select(a => (UserRoleRequestDto)a).ToList();
                return Ok(userRoleAcceptations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("roles/addrequest")]
        public async Task<IActionResult> AddUserRoleRequest([FromBody] UserRoleRequestDto roleRequest)
        {
            try
            {
                UserRoleRequest entity = new UserRoleRequest();
                entity.RoleId = roleRequest.RoleId;
                entity.UserId = roleRequest.UserId;
                entity.Status = UserRoleRequestStatus.Pending;

                await _userRoleRequestsRepository.Save(entity);

                entity = await _userRoleRequestsRepository.Get(entity.Id);

                return Ok((UserRoleRequestDto)entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("roles/requests")]
        public async Task<IActionResult> GetRoleRequest()
        {
            try
            {
                var pendingRequestEntities = await _userRoleRequestsRepository.GetPendingRequests();
                var pendingRequest = pendingRequestEntities.Select(a => (UserRoleRequestDto)a).ToList();
                return Ok(pendingRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("roles/acceptrequest")]
        public async Task<IActionResult> AcceptRoleRequest([FromBody] UserRoleRequestDto roleRequest)
        {
            try
            {
               
                UserRoleRequest entity = await _userRoleRequestsRepository.Get(roleRequest.Id);
                entity.RoleId = roleRequest.RoleId;
                entity.UserId = roleRequest.UserId;
                entity.AcceptedByUserId = User.GetUserId();
                entity.AcceptationDate = DateTime.UtcNow;
                entity.Status = UserRoleRequestStatus.Accepted;

                await _userRoleRequestsRepository.Save(entity);

                UserRolesManager userRolesManager = new UserRolesManager(_userManager);
                await userRolesManager.AddUserToRole(roleRequest.UserId, roleRequest.RoleName);

                return Ok(roleRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("roles/rejectrequest")]
        public async Task<IActionResult> RejectRoleRequest([FromBody] UserRoleRequestDto roleRequest)
        {
            try
            {
                UserRoleRequest entity = await _userRoleRequestsRepository.Get(roleRequest.Id);
                entity.RoleId = roleRequest.RoleId;
                entity.UserId = roleRequest.UserId;
                entity.AcceptedByUserId = User.GetUserId();
                entity.AcceptationDate = DateTime.UtcNow;
                entity.Status = UserRoleRequestStatus.Rejected;

                await _userRoleRequestsRepository.Save(entity);

                return Ok(roleRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}