using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Roles;

namespace MuaythaiSportManagementSystemApi.Controllers
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
                var roles = rolesEntities.Select(r => (RoleDto)r).ToList();
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
                var roles = rolesEntities.Select(r => (RoleDto)r).ToList();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
