using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Locations
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public static explicit operator CountryModel(Country country)
        {
            if (country == null)
            {
                return null;
            }
            return new CountryModel
            {
                Id = country.Id,
                Code = country.Code,
                Name = country.Name
            };
        }
    }

    
}
