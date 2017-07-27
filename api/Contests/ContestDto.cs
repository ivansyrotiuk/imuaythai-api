using MuaythaiSportManagementSystemApi.Dictionaries;
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
        public string Address { get; set; }
        public int Duration { get; set; }
        public int RingsCount { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public bool AllowUnassociated { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string VK { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; } 
       // public List<Contest> ContestCategories { get; set; }
    }
}
