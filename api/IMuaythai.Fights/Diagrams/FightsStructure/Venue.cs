namespace IMuaythai.Fights.Diagrams.FightsStructure
{
    public class Venue
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public Location Location { get; set; }
        public Tourney Tourney { get; set; }
    }
}