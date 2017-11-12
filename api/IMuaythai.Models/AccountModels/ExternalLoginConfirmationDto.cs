using System.ComponentModel.DataAnnotations;

namespace IMuaythai.Models.AccountModels
{
    public class ExternalLoginConfirmationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
