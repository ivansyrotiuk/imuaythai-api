namespace IMuaythai.Fights.Diagrams.FightsStructure
{
    public class League
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public int Created { get; set; }
        public int Updated { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string[] schoolGamesLeagues { get; set; }
    }
}