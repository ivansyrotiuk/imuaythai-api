using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public class ContestPointsDto
    {
        public int Id { get; set; }
        public int ContestTypeId { get; set; }
        public int ContestRangeId { get; set; }
        public int? InstitutionId { get; set; }
        public decimal Points { get; set; }

        public ContestTypeDto ContestType { get; set; }
        public ContestRangeDto ContestRange { get; set; }
        public Institution Institution { get; set; }

        public static explicit operator ContestPointsDto(ContestTypePoints points)
        {
            return new ContestPointsDto
            {
                Id = points.Id,
                Points = points.Points,
                ContestRangeId = points.ContestRangeId,
                ContestTypeId = points.ContestTypeId,
                ContestRange = points.ContestRange != null ? (ContestRangeDto)points.ContestRange : new ContestRangeDto(),
                ContestType = points.ContestType != null ? (ContestTypeDto)points.ContestType : new ContestTypeDto()
            };
        }
    }
}
