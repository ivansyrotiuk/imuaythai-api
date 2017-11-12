using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class KhanLevelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public static explicit operator KhanLevelModel(KhanLevel khan)
        {
            if (khan == null)
            {
                return null;
            }

            return new KhanLevelModel
            {
                Id = khan.Id,
                Name = khan.Name,
                Level = khan.Level
            };
        }
    }
}
