namespace MuaythaiSportManagementSystemApi.Fights.FightsStructure
{
    public class Division
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
        public Tourney Tourney { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
    }
}