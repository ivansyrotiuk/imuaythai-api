namespace IMuaythai.DataAccess.Models
{
    public class InstitutionDocumentsMapping
    {
        public int Id { get; set; }
        public int InstitutionId { get; set; }

        public Document Document { get; set; }
        public Institution Institution { get; set; }

    }
}
