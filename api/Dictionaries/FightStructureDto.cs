using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class FightStructureDto
    {
        public int Id { get; set; }
        public int WeightAgeCategoryId { get; set; }
        public int RoundId { get; set; }

        public WeightAgeCategory WeightAgeCategory { get; set; }
        public Round Round { get; set; }

        public static explicit operator FightStructureDto(FightStructure structure)
        {
            if (structure == null)
            {
                return null;
            }

            return new FightStructureDto
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
