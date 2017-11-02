using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public class KhanLevelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public static explicit operator KhanLevelDto(KhanLevel khan)
        {
            if (khan == null)
            {
                return null;
            }

            return new KhanLevelDto
            {
                Id = khan.Id,
                Name = khan.Name,
                Level = khan.Level
            };
        }
    }
}
