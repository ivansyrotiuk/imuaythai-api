namespace IMuaythai.Models.Dictionaries
{
    public class FightStructureModel
    {
        public int Id { get; set; }
        public int WeightAgeCategoryId { get; set; }
        public int RoundId { get; set; }

        public WeightAgeCategoryModel WeightAgeCategory { get; set; }
        public RoundModel Round { get; set; }
    }
}
