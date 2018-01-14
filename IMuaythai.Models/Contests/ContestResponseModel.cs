using System;
using System.Collections.Generic;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Locations;

namespace IMuaythai.Models.Contests
{
    public class ContestResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndRegistrationDate { get; set; }
        public string Address { get; set; }
        public int Duration { get; set; }
        public int RingsCount { get; set; }
        public string City { get; set; }
        public bool AllowUnassociated { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        // ReSharper disable once InconsistentNaming
        public string VK { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public int InstitutionId { get; set; }
        public int CountryId { get; set; }
        public int? ContestRangeId { get; set; }
        public int? ContestTypeId { get; set; }
        public int WaiKhruTime { get; set; }
        public CountryModel Country { get; set; }
        public List<ContestRingModel> Rings { get; set; } 
        public InstitutionResponseModel InstitutionResponse { get; set; }
        public List<ContestCategoryModel> ContestCategories { get; set; }

    }
}
