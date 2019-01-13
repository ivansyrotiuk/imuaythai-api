using System;

namespace IMuaythai.Models.Licenses
{
    public class UserLicense
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public bool OneOff { get; set; }
    }
}