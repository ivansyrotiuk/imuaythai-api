namespace IMuaythai.DataAccess.Models
{
    public class ContestDocumentsMapping
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int InstitutionId { get; set; }

        public Document Document { get; set; }
        public Contest Institution { get; set; }

    }
}
