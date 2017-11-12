using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class FightStructureModel
    {
        public int Id { get; set; }
        public int WeightAgeCategoryId { get; set; }
        public int RoundId { get; set; }

        public WeightAgeCategory WeightAgeCategory { get; set; }
        public Round Round { get; set; }

        public static explicit operator FightStructureModel(FightStructure structure)
        {
            if (structure == null)
            {
                return null;
            }

            return new FightStructureModel
            {
                Id = structure.Id,
                WeightAgeCategoryId = structure.WeightAgeCategoryId,
                RoundId = structure.RoundId,
                WeightAgeCategory = structure.WeightAgeCategory != null ? structure.WeightAgeCategory : new WeightAgeCategory(),
                Round = structure.Round != null ? structure.Round : new Round()
            };
        }
    }
}
