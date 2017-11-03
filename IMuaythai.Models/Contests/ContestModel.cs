using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Locations;

namespace IMuaythai.Models.Contests
{
    public class ContestModel
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
        public List<ContestCategoryModel> ContestCategories { get; set; }
        public CountryModel Country { get; set; }
        public List<ContestRingModel> Rings { get; set; } 
        public InstitutionModel Institution { get; set; }

        public ContestModel()
        {

        }

        public ContestModel(Contest contest)
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
            Country = (CountryModel) contest.Country;
            Institution = (InstitutionModel)contest.Institution;
            ContestCategories = contest.ContestCategoriesMappings?.Select(c => (ContestCategoryModel)c.ContestCategory).ToList() ?? new List<ContestCategoryModel>();
            Rings = contest.Rings?.GroupBy(r => r.From.Date).Select(g => new ContestRingModel
            {
                ContestDay = g.Key,
                RingsCount = g.Count(),
                ContestId = g.Select(e => e.ContestId).FirstOrDefault(),
                RingsAvilability = g.Select(a => (RingAvailabilityModel)a).ToList()
            }).ToList();
        }

        public static explicit operator ContestModel(Contest contest)
        {
            if (contest == null)
            {
                return null;
            }
            return new ContestModel(contest);
        }
    }
}
