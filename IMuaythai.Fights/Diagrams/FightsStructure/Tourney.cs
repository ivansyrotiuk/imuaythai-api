namespace IMuaythai.Fights.Diagrams.FightsStructure
{
    public class Tourney
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
        public string Name { get; set; }
        public bool Custom { get; set; }
        public Location Location { get; set; }
        public int AccountId { get; set; }
        public string TimeZone { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }
        public string Acronym { get; set; }
        public Session Session { get; set; }
        public string SourceType { get; set; }
        public string MaxLastScraped { get; set; }

    }
}