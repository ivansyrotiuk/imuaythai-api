using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Models.Roles;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var rolesEntities = await _rolesRepository.GetAll();
                var roles = rolesEntities.Select(r => (RoleModel)r).ToList();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("public")]
        public async Task<IActionResult> GetPublicRoles()
        {
            try
            {
                var rolesEntities = await _rolesRepository.GetPublicRoles();
                var roles = rolesEntities.Select(r => (RoleModel)r).ToList();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("contest")]
        public async Task<IActionResult> GetContestRoles()
        {
            try
            {
                var rolesEntities = await _rolesRepository.GetContestRoles();
                var roles = rolesEntities.Select(r => (RoleModel)r).ToList();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
