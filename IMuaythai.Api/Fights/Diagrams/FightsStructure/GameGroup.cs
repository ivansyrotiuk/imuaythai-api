namespace IMuaythai.Api.Fights.Diagrams.FightsStructure
{
    public class GameGroup
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
        public Division Division { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public string Type { get; set; }
    }
}