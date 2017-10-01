using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class KhanLevelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public static explicit operator KhanLevelDto(KhanLevel khan)
        {
            return new KhanLevelDto
            {
                Id = khan?.Id ?? 0,
                Name = string.IsNullOrEmpty(khan?.Name)? "_": khan?.Name,
                Level = khan?.Level??0
            };
        }
    }
}
