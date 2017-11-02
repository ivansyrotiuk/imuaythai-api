namespace IMuaythai.Api.Fights.Diagrams.FightsStructure
{
    public class Team
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
        public GameGroup Pool { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public int NumGames { get; set; }
        public Standing Standing { get; set; }

    }
}