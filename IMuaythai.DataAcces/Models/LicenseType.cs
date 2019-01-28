using System.Collections.Generic;

namespace IMuaythai.DataAccess.Models
{
    public class LicenseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public LicenseKinds Kind { get; set; }
        public bool OneOff { get; set; }
        public int CountryId { get; set; }
        public virtual ICollection<License> Licenses { get; set; }
    }
}