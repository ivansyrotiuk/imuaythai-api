using System;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using System.Linq;
using MuaythaiSportManagementSystemApi.Users;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Figthers")]
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

    }
}