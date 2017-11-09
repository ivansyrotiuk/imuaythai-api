using System;
using System.Threading.Tasks;
using IMuaythai.Institutions;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Institutions
{
    [Route("api/[controller]")]
    public class FederationsController : Controller
    {
        private readonly IFederationsService _federationsService;

        public FederationsController(IFederationsService federationsService)
        {
            _federationsService = federationsService;
        }

        [HttpGet]
        [Route("National")]
        public async Task<IActionResult> GetNationalFederations()
        {
            try
            {
                var federations = await _federationsService.GetNationalFederations();
                return Ok(federations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Continental")]
        public async Task<IActionResult> GetContinentalFederations()
        {
            try
            {
                var federations = await _federationsService.GetContinentalFederations();
                return Ok(federations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("World")]
        public async Task<IActionResult> WorldFederations()
        {
            try
            {
                var federations = await _federationsService.GetWorldFederations();
                return Ok(federations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("Useravailable")]
        //public async Task<IActionResult> GetUserAvailableFederations([FromQuery] string userId)
        //{
        //    try
        //    {
        //        var user = await _userManager.FindByIdAsync(userId);
        //        if (user == null)
        //        {
        //            return BadRequest("User not found");
        //        }

        //        if (user.CountryId == null)
        //        {
        //            return BadRequest("Select country.");
        //        }

        //        var country = await _countryRepository.Get(user.CountryId.Value);

        //        var entities = await _repository.GetByCountry(country);
        //        var federations = entities.Select(i => (InstitutionModel)i).ToList();
        //        return Ok(federations);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}