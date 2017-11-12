using System;
using System.Threading.Tasks;
using IMuaythai.Institutions;
using IMuaythai.Repositories.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Institutions
{
    [Route("api/[controller]")]
    public class GymsController : Controller
    {
        private readonly ICountriesRepository _countryRepository;
        private readonly IGymsService _gymsService;

        public GymsController(IGymsService gymsService, ICountriesRepository countryRepository)
        {
            _gymsService = gymsService;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var gyms = await _gymsService.GetGyms();
                return Ok(gyms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Country")]
        public async Task<IActionResult> GetGymsInCountry([FromQuery]int id)
        {
            try
            {
                var country = await _countryRepository.Get(id);
                if (country == null)
                {
                    return BadRequest("Country not found");
                }

                var gyms = await _gymsService.GetCountryGyms(id);
                return Ok(gyms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}