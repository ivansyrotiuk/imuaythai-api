namespace IMuaythai.Models.Dictionaries
{
    public class ContestPointsModel
    {
        public int Id { get; set; }
        public int ContestTypeId { get; set; }
        public int ContestRangeId { get; set; }
        public int? InstitutionId { get; set; }
        public decimal Points { get; set; }

        public ContestTypeModel ContestType { get; set; }
        public ContestRangeModel ContestRange { get; set; }
    }
}
