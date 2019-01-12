namespace IMuaythai.DataAccess.Models
{
    public class GymLicense : License
    {
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }
    }
}