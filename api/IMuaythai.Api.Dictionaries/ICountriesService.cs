using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Models.Locations;

namespace IMuaythai.Dictionaries
{
    public interface ICountriesService
    {
        Task<IEnumerable<CountryModel>> GetCountries();
    }
}