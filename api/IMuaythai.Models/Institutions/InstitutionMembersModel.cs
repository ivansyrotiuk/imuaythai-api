using System.Collections.Generic;
using IMuaythai.Models.Users;

namespace IMuaythai.Models.Institutions
{
    public class InstitutionMembersModel
    {
        public IEnumerable<UserModel> Fighters { get; set; }
        public IEnumerable<UserModel> Judges { get; set; }
        public IEnumerable<UserModel> Doctors { get; set; }
        public IEnumerable<UserModel> Coaches { get; set; }
    }
}