using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Institutions.Gyms
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

        public  List<InstitutionDocumentsMapping> InstitutionDocumentsMappings { get; set; }
        public  List<ContestRequest> ContestRequests { get; set; }
        public  List<ApplicationUser> Users { get; set; }
        public  List<ExecutionBoard> ExecutionBoards { get; set; }
        public  List<Contest> Contests { get; set; }
        public  Country Country { get; set; }

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
        }

        public static explicit operator InstitutionDto(Institution institution)
        {
            return new InstitutionDto(institution);
        }
    }
}
