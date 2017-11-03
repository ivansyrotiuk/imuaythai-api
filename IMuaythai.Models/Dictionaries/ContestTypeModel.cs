using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class ContestTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator ContestTypeModel(ContestType type)
        {
            return new ContestTypeModel
            {
                Id = type.Id,
                Name = type.Name
            };
        }
    }
}
