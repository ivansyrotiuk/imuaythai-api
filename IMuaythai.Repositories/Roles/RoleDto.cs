using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Repositories.Roles
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }


        public RoleDto()
        {

        }

        public RoleDto(IdentityRole role)
        {
            Id = role.Id;
            Name = role.Name;
            NormalizedName = role.NormalizedName;
        }

        public static explicit operator RoleDto(IdentityRole role)
        {
            return new RoleDto(role);
        }
    }
}
