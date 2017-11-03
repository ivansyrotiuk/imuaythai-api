using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class SuspensionTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public static explicit operator SuspensionTypeModel(SuspensionType suspension)
        {
            return new SuspensionTypeModel
            {
                Id = suspension.Id,
                Name = suspension.Name
            };
        }
    }
}
