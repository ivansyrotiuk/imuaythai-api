namespace IMuaythai.DataAccess.Models
{
    public class License
    {
        public int Id { get; set; }
        public int Duration { get; set; } //in days
        public double Price { get; set; }
        public string Currency { get; set; }
        public LicenseType Type { get; set; }
        public bool OneOff { get; set; }
    }

    public enum LicenseType
    {
        Gym,
        Fighter,
        Judge,
        Coach,
    }
}