using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class ContestCategoryDto
    {
        public int Id { get; set; }
        public int ContestTypePointsId { get; set; }
        public int FightStructureId { get; set; }
        public string Name { get; set; }
        public string ContestTypeName => ContestPoints?.ContestType?.Name;
        public string ContestRangeName => ContestPoints?.ContestRange?.Name;
        public string RoundName => FightStructure?.Round?.Name;
        public string WeightCategoryName => FightStructure?.WeightAgeCategory?.Name;

        public ContestPointsDto ContestPoints { get; set; }
        public FightStructureDto FightStructure { get; set; }

        public ContestCategoryDto()
        {

        }
        public ContestCategoryDto(ContestCategory category)
        {
            Id = category.Id;
            Name = category.Name;
            ContestTypePointsId = category.ContestTypePointsId;
            FightStructureId = category.FightStructureId;
            ContestPoints = category.ContestTypePoints != null ? (ContestPointsDto)category.ContestTypePoints : new ContestPointsDto();
            FightStructure = category.FightStructure != null ? (FightStructureDto)category.FightStructure : new FightStructureDto();
        }

        public static explicit operator ContestCategoryDto(ContestCategory category)
        {
            if (category == null)
            {
                return null;
            }
            return new ContestCategoryDto(category);
        }
    }
}
