using IMuaythai.DataAccess.Models;
using IMuaythai.Repositories.Locations;

namespace IMuaythai.Repositories.Institutions
{
    public class InstitutionDto{
        public int Id { get; set; }
        public string Name { get; set; }

        public string Logo { get; set; }
      
        public string Address { get; set; }     
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }

        public string ContactPerson { get; set; }      
        public string Phone { get; set; }     
        public string Email { get; set; }   
        
        public string HeadCoachId { get; set; }  
    
        public string Owner { get; set; }     
        
        public string Website { get; set; }       
        public string Facebook { get; set; }       
        public string Instagram { get; set; }    
        public string VK { get; set; }
       
        public string Twitter { get; set; }
        public int MembersCount { get; set; }
        public InstitutionType InstitutionType { get; set; }

        
        public  CountryDto Country { get; set; }

        public InstitutionDto()
        {

        }

        public InstitutionDto(Institution institution)
        {
            Id = institution.Id;
            Name = institution.Name;
            Logo = institution.Logo;
            Address = institution.Address;
            City = institution.City;
            ZipCode = institution.ZipCode;
            CountryId = institution.CountryId;
            ContactPerson = institution.ContactPerson;
            Phone = institution.Phone;
            Email = institution.Email;
            HeadCoachId = institution.HeadCoachId;
            Owner = institution.Owner;
            Website = institution.Website;
            Facebook = institution.Facebook;
            Instagram = institution.Instagram;
            VK = institution.VK;
            Twitter = institution.Twitter;
            MembersCount = institution.MembersCount;
            InstitutionType = institution.InstitutionType;
            Country = (CountryDto)institution.Country;
        }

        public static explicit operator InstitutionDto(Institution institution)
        {
            if (institution == null)
            {
                return null;
            }
            return new InstitutionDto(institution);
        }
    }
}
