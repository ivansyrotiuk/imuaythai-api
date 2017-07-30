namespace MuaythaiSportManagementSystemApi.Fights.FightsStructure
{
    public class Venue
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public int Created { get; set; }
        public int Updated { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public Location Location { get; set; }
        public Tourney Tourney { get; set; }
    }
}