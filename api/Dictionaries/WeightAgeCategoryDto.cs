using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class WeightAgeCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public string Gender { get; set; }

        public static explicit operator WeightAgeCategoryDto(WeightAgeCategory category)
        {
            return new WeightAgeCategoryDto
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
