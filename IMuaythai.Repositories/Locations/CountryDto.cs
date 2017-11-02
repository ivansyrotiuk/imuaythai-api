using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Locations
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public static explicit operator CountryDto(Country country)
        {
            if (country == null)
            {
                return null;
            }
            return new CountryDto
            {
                Id = country.Id,
                Code = country.Code,
                Name = country.Name
            };
        }
    }

    
}
