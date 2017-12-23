using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Locations;

namespace IMuaythai.Models.Institutions
{
    public class InstitutionModel{
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
        // ReSharper disable once InconsistentNaming
        public string VK { get; set; }
        public string Twitter { get; set; }
        public int MembersCount { get; set; }
        public InstitutionType InstitutionType { get; set; }
        public  CountryModel Country { get; set; }
    }
}
