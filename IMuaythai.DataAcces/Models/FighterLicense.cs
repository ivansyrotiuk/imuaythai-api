namespace IMuaythai.DataAccess.Models
{
    public class FighterLicense : License
    {
        public string FighterId { get; set; }
        public ApplicationUser Fighter { get; set; }
    }
}