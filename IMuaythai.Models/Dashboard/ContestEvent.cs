using System;

namespace IMuaythai.Models.Dashboard
{
    public class ContestEvent
    {
        public int ContestId { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Organizator { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
