using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Locations;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly ICountriesRepository _countryRepository;

        public LocationsController(ICountriesRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        [Route("countries")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var countryEntities = await _countryRepository.GetAll();
                var countries = countryEntities.Select(c => (CountryDto)c).ToList();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
