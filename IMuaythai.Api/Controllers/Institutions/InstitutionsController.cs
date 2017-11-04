using System;
using System.Threading.Tasks;
using IMuaythai.Institutions;
using IMuaythai.Models.Institutions;
using IMuaythai.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Institutions
{
    [Route("api/[controller]")]
    public class InstitutionsController : Controller
    {
        private readonly IInstitutionsService _institutionsService;
        private readonly IFileSaver _fileSaver;
        public InstitutionsController(IInstitutionsService institutionsService, IFileSaver fileSaver)
        {
            _institutionsService = institutionsService;
            _fileSaver = fileSaver;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetInstitution([FromRoute]int id)
        {
            try
            {
                var institution = await _institutionsService.Get(id);
                return Ok(institution);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody]InstitutionModel institution)
        {
            try
            {
                var imageBase64 = institution.Logo?.Split(',');
                if (imageBase64?.Length > 1)
                {
                    string hostUrl = $"{Request.Scheme}://{Request.Host}";
                    institution.Logo = await _fileSaver.Save(hostUrl, imageBase64[1]);
                }

                institution = await _institutionsService.Save(institution);
                return Created("Add", institution);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromBody]InstitutionModel institution)
        {
            try
            {
                await _institutionsService.Remove(institution.Id);

                return Ok(institution.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}