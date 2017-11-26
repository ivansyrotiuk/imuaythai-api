using System;
using System.Collections.Generic;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Models.Users
{
    public class UserModel
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
        // ReSharper disable once InconsistentNaming
        public string VK { get; set; }
        public string CoachLevel { get; set; }
        public bool Accepted { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string AvatarImage { get; set; }
        public string GymName { get; set; }
    }

    public class FighterModel : UserModel
    {
        public int FightsCount { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public KhanLevelModel KhanLevel { get; set; }
        public int Age { get; set; }
    }

    public class JudgeModel : FighterModel
    {

    }
}
