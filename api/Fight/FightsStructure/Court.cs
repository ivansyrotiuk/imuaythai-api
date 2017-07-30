namespace MuaythaiSportManagementSystemApi.Fights.FightsStructure
{
    public class Court
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public int Created { get; set; }
        public int Updated { get; set; }
        public Venue Venue { get; set; }
        public string Name { get; set; }
    }
}