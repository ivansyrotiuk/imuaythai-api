using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;
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
        public string VK { get; set; }
        public string CoachLevel { get; set; }
        public bool Accepted { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string AvatarImage { get; set; }

        public UserModel()
        {

        }

        public UserModel(ApplicationUser user)
        {
            if (user == null)
            {
                return;
            }
            Id = user.Id;
            Firstname = user.FirstName;
            Surname = user.Surname;
            Birthdate = user.Birthdate;
            Nationality = user.Nationality;
            Facebook = user.Facebook;
            Twitter = user.Twitter;
            Instagram = user.Instagram;
            InstitutionId = user.InstitutionId;
            VK = user.VK;
            Gender = user.Gender;
            Phone = user.Phone;
            CountryId = user.CountryId;
            CountryName = user.Country?.Name;
            Email = user.Email;
            //TODO: Add roles from userRoles
            Roles = user.Roles?.Select(r => r.RoleId).ToList();
            Photo = user.Photo;
        }

        public static explicit operator UserModel(ApplicationUser user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserModel(user);
        }
    }

    public class FighterModel : UserModel
    {
        public string GymName { get; set; }
        public int FightsCount { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public KhanLevelModel KhanLevel { get; set; }
        public int Age => Math.Abs(DateTime.Today.Year - Birthdate.Year);

        public FighterModel()
        {

        }

        public FighterModel(ApplicationUser user):base(user)
        {
            GymName = user?.Institution?.Name;
            KhanLevel = (KhanLevelModel)user?.KhanLevel;
        }

        public static explicit operator FighterModel(ApplicationUser user)
        {
            return new FighterModel(user);
        }
    }

    public class JudgeModel : FighterModel
    {
        public JudgeModel()
        {

        }

        public JudgeModel(ApplicationUser user) : base(user)
        {
           
        }


        public static explicit operator JudgeModel(ApplicationUser user)
        {
            return new JudgeModel(user);
        }
    }


}
