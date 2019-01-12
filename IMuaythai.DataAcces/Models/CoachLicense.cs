namespace IMuaythai.DataAccess.Models
{
    public class CoachLicense : License
    {
        public string CoachId { get; set; }
        public ApplicationUser Coach { get; set; }
    }
}