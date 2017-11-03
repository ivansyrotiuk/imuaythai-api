using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class ContestCategoryModel
    {
        public int Id { get; set; }
        public int ContestTypePointsId { get; set; }
        public int FightStructureId { get; set; }
        public string Name { get; set; }
        public int ServiceBreakDuration { get; set; }
        public string ContestTypeName => ContestPoints?.ContestType?.Name;
        public string ContestRangeName => ContestPoints?.ContestRange?.Name;
        public string RoundName => FightStructure?.Round?.Name;
        public string WeightCategoryName => FightStructure?.WeightAgeCategory?.Name;

        public ContestPointsModel ContestPoints { get; set; }
        public FightStructureModel FightStructure { get; set; }

        public ContestCategoryModel()
        {

        }
        public ContestCategoryModel(ContestCategory category)
        {
            Id = category.Id;
            Name = category.Name;
            ServiceBreakDuration = category.ServiceBreakDuration;
            ContestTypePointsId = category.ContestTypePointsId;
            FightStructureId = category.FightStructureId;
            ContestPoints = category.ContestTypePoints != null ? (ContestPointsModel)category.ContestTypePoints : new ContestPointsModel();
            FightStructure = category.FightStructure != null ? (FightStructureModel)category.FightStructure : new FightStructureModel();
        }

        public static explicit operator ContestCategoryModel(ContestCategory category)
        {
            if (category == null)
            {
                return null;
            }
            return new ContestCategoryModel(category);
        }
    }
}
