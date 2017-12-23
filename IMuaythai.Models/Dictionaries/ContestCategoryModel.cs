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
    }
}
