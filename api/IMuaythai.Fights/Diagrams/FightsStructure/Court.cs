namespace IMuaythai.Fights.Diagrams.FightsStructure
{
    public class Court
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
        public Venue Venue { get; set; }
        public string Name { get; set; }
    }
}