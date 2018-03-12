
namespace IMuaythai.Models.AccountModels
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string CallbackUrl { get; set; }
    }
}
