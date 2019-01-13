using System;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using IMuaythai.Shared;
using IMuaythai.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IFilesService _fileService;

        public UsersController(IUsersService usersService, 
            IUserRoleRequestsRepository userRoleAcceptationsRepository, IFilesService filesService,
            UserManager<ApplicationUser> userManager)
        {
            _usersService = usersService;
            _fileService = filesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _usersService.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("fighters")]
        public async Task<IActionResult> GetFigthers()
        {
            try
            {
                var fighters = await _usersService.GetFigthers();
                return Ok(fighters);
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
                var judges = await _usersService.GetJudges();
                return Ok(judges);
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
                var coaches = await _usersService.GetCoaches();
                return Ok(coaches);
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
                var doctors = await _usersService.GetDoctors();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {

            var user = await _usersService.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveUser([FromBody]UserModel userModel)
        {
            try
            {
                userModel.Photo = _fileService.UploadFile(userModel.Photo) ?? userModel.Photo;
                var user = await _usersService.SaveUser(userModel);
                return Created("Add", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveUser([FromBody]UserModel user)
        {
            try
            {
                await _usersService.RemoveUser(user.Id);
                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}