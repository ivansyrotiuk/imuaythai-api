using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class WeightAgeCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public string Gender { get; set; }

        public static explicit operator WeightAgeCategoryModel(WeightAgeCategory category)
        {
            return new WeightAgeCategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                MinAge = category.MinAge,
                MaxAge = category.MaxAge,
                MinWeight = category.MinWeight,
                MaxWeight = category.MaxWeight,
                Gender = category.Gender
            };
        }
    }
}
