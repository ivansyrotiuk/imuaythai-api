using IMuaythai.DataAccess.Models;

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
        public Institution Institution { get; set; }

        public static explicit operator ContestPointsModel(ContestTypePoints points)
        {
            return new ContestPointsModel
            {
                Id = points.Id,
                Points = points.Points,
                ContestRangeId = points.ContestRangeId,
                ContestTypeId = points.ContestTypeId,
                ContestRange = points.ContestRange != null ? (ContestRangeModel)points.ContestRange : new ContestRangeModel(),
                ContestType = points.ContestType != null ? (ContestTypeModel)points.ContestType : new ContestTypeModel()
            };
        }
    }
}
