namespace IMuaythai.Models.AccountModels
{
    public class FinishRegistrationModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string RoleId { get; set; }
        public bool? OwnGym { get; set; }
        public string GymName { get; set; }
        public int CountryId { get; set; }
        public int? InstitutionId { get; set; }
    }
}