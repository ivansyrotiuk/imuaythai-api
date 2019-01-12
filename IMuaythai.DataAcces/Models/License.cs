using System;

namespace IMuaythai.DataAccess.Models
{
    public enum LicenseKinds
    {
        Gym,
        Fighter,
        Judge,
        Coach,
    }

    public abstract class License
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public bool Paid { get; set; }
        public int PaymentMethod { get; set; }
        public int ContestId { get; set; }
        public int LicenseTypeId { get; set; }
        public LicenseKinds Kind { get; set; }
        public string OrderId { get; set; }
        public virtual LicenseType LicenseType { get; set; }
    }
}