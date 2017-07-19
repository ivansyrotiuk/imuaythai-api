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

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private IUsersRepository _repository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IUsersRepository repository, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("fighters")]
        public IActionResult GetFigthers()
        {
            try
            {
                IUsersRepository fightersRepository = new FightersRepository(_repository);
                var users = fightersRepository.GetAll().Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("fighters/{id}")]
        public async Task<IActionResult> GetFigthers([FromRoute]string id)
        {
            try
            {
                Thread.Sleep(1000);
                IUsersRepository fightersRepository = new FightersRepository(_repository);
                var figther = fightersRepository.Get(id);
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
        public IActionResult GetJudges()
        {
            try
            {
                var users = _repository.GetAll().Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Coaches")]
        public IActionResult GetCoaches()
        {
            try
            {
                var users = _repository.GetAll().Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Doctors")]
        public IActionResult GetDoctors()
        {
            try
            {
                var users = _repository.GetAll().Select(u => (UserDto)u).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Save")]
        public IActionResult SaveUser([FromBody]UserDto user)
        {
            try
            {
                ApplicationUser userEntity = string.IsNullOrEmpty(user.Id) ? new ApplicationUser() : _repository.Get(user.Id);
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

                _repository.Save(userEntity);

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
        [Route("roles")]
        public Task<IActionResult> GetUserRoles()
        {
            return null;
        }
    }
}