using System;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Licenses
{
    public class LicenseResponseModel
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public bool Paid { get; set; }
        public int PaymentMethod { get; set; }
        public int ContestId { get; set; }
        public int LicenseTypeId { get; set; }
        public LicenseKinds Kind { get; set; }
        public string OrderId { get; set; }
        
    }

    public class FighterLicenseResponseModel : LicenseResponseModel
    {
        public string FighterId { get; set; }
    }

    public class GymLicenseResponseModel : LicenseResponseModel
    {
        public int InstitutionId { get; set; }
    }

    public class CoachLicenseResponseModel : LicenseResponseModel
    {
        public string CoachId { get; set; }
    }

    public class JudgeLicenseResponseModel : LicenseResponseModel
    {
        public string JudgeId { get; set; }
    }

    public class LicenseTypeResponseModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public bool OneOff { get; set; }
        public string Name { get; set; }
        public LicenseKinds Kind { get; set; }
        public int? InstitutionId { get; set; }
    }
}
