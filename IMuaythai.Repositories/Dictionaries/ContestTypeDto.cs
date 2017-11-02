using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public class ContestTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator ContestTypeDto(ContestType type)
        {
            return new ContestTypeDto
            {
                Id = type.Id,
                Name = type.Name
            };
        }
    }
}
