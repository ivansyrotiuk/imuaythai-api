using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class SuspensionTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public static explicit operator SuspensionTypeDto(SuspensionType suspension)
        {
            return new SuspensionTypeDto
            {
                Id = suspension.Id,
                Name = suspension.Name
            };
        }
    }
}
