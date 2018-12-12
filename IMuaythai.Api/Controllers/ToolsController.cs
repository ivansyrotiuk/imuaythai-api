using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Auth;
using IMuaythai.Models.Users;
using IMuaythai.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Tools")]
    public class ToolsController : Controller
    {
        private readonly IUsersService _usersService;

        public ToolsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("........");
        }

        [HttpPost]
        [Route("batch/fighters")]
        public IActionResult CreateFightersBatch([FromBody] CreateUserModel[] createUserModels)
        {
            foreach (var model in createUserModels)
            {
                model.Password = Guid.NewGuid().ToString();
                model.Accepted = true;
                model.CountryId = 2;
                model.Email = $"{Guid.NewGuid()}@gmail.com";
                model.RoleId = "e64aa945-0324-426f-9e8a-3700f839fcc5";
                model.InstitutionId = 12;
            }

            var tasks = createUserModels.Select(m => _usersService.CreateUser(m)).ToArray();
            Task.WaitAll(tasks);

            return Ok();
        }
    }
}