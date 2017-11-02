namespace IMuaythai.Api.Fights.Diagrams.FightsStructure
{
    public class Game
    {
        public object[] AccountEventData { get; set; }
        public object[] AccountFollowedTeams { get; set; }
        public object[] AccountRecruits { get; set; }
        public object[] AccountUserEventData { get; set; }
        public bool Cancelled { get; set; }
        public Court Court { get; set; }
        public long Created { get; set; }
        public int DurationInMinutes { get; set; }
        public string EventType { get; set; }
        public string ExternalId { get; set; }
        public GameGroup GameGroup { get; set; }
        public ScoreNode HomeScore { get; set; }
        public Seed HomeSeed { get; set; }
        public Team HomeTeam { get; set; }
        public string Id { get; set; }
        public bool IgnoreStandings { get; set; }
        public object LastScraped { get; set; }
        public string LocalDate { get; set; }
        public string Name { get; set; }
        public object[] Recruits { get; set; }
        public long Scheduled { get; set; }
        public Sides Sides { get; set; }
        public long Updated { get; set; }
        public int Version { get; set; }
        public ScoreNode VisitorScore { get; set; }
        public Seed VisitorSeed { get; set; }
        public Team VisitorTeam { get; set; }

    }
}
