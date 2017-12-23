using System;
using System.Collections.Generic;
using System.Text;

namespace IMuaythai.Models.Users
{
    public class CreateUserModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public int Type { get; set; }
        public int? CountryId { get; set; }
        public int? InstitutionId { get; set; }
        public int? KhanLevelId { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string VK { get; set; }
        public string CoachLevel { get; set; }
        public bool Accepted { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string Password { get; set; }
        public string AvatarImage { get; set; }
    }
}
