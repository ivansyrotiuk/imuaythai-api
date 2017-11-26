using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.Models.Locations;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface ICountriesService
    {
        Task<IEnumerable<CountryModel>> GetCountries();
    }

    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesService(ICountriesRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryModel>> GetCountries()
        {
            var countries = await _countryRepository.GetAll();
            return _mapper.Map<IEnumerable<CountryModel>>(countries);
        }
    }
}