namespace IMuaythai.DataAccess.Models
{
    public class JudgeLicense : License
    {
        public string JudgeId { get; set; }
        public ApplicationUser Judge { get; set; }
    }
}