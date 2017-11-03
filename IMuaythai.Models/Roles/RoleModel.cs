using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Models.Roles
{
    public class RoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }


        public RoleModel()
        {

        }

        public RoleModel(IdentityRole role)
        {
            Id = role.Id;
            Name = role.Name;
            NormalizedName = role.NormalizedName;
        }

        public static explicit operator RoleModel(IdentityRole role)
        {
            return new RoleModel(role);
        }
    }
}
