using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Institutions;
using MuaythaiSportManagementSystemApi.Locations;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Contests
{
    public class ContestDto
    {
        public int Id { get;  set; }
        public string  Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndRegistrationDate { get; set; }
        public string Address { get; set; }
        public int Duration { get; set; }
        public int RingsCount { get; set; }
        public string City { get; set; }
        public bool AllowUnassociated { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string VK { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public int InstitutionId { get; set; }
        public int CountryId { get; set; }
        public int? ContestRangeId { get; set; }
        public int? ContestTypeId { get; set; }
        public int WaiKhruTime { get; set; }
        public List<ContestCategoryDto> ContestCategories { get; set; }
        public CountryDto Country { get; set; }
        public List<ContestRingDto> Rings { get; set; } 
        public InstitutionDto Institution { get; set; }

        public ContestDto()
        {

        }

        public ContestDto(Contest contest)
        {
            Id = contest.Id;
            Name = contest.Name;
            Date = contest.Date;
            EndRegistrationDate = contest.EndRegistrationDate;
            Address = contest.Address;
            Duration = contest.Duration;
            RingsCount = contest.RingsCount;
            City = contest.City;
            AllowUnassociated = contest.AllowUnassociated;
            Website = contest.Website;
            Facebook = contest.Facebook;
            VK = contest.VK;
            Twitter = contest.Twitter;
            Instagram = contest.Instagram;
            InstitutionId = contest.InstitutionId;
            CountryId = contest.CountryId;
            ContestRangeId = contest.ContestRangeId;
            ContestTypeId = contest.ContestTypeId;
            WaiKhruTime = contest.WaiKhruTime;
            Country = (CountryDto) contest.Country;
            Institution = (InstitutionDto)contest.Institution;
            ContestCategories = contest.ContestCategoriesMappings?.Select(c => (ContestCategoryDto)c.ContestCategory).ToList() ?? new List<ContestCategoryDto>();
            Rings = contest.Rings?.GroupBy(r => r.From.Date).Select(g => new ContestRingDto
            {
                ContestDay = g.Key,
                RingsCount = g.Count(),
                ContestId = g.Select(e => e.ContestId).FirstOrDefault(),
                RingsAvilability = g.Select(a => (RingAvailabilityItem)a).ToList()
            }).ToList();
        }

        public static explicit operator ContestDto(Contest contest)
        {
            return new ContestDto(contest);
        }
    }
}
