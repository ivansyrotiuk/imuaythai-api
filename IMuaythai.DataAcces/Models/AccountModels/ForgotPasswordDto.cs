using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models.AccountModels
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string CallbackUrl { get; set; }
    }
}
