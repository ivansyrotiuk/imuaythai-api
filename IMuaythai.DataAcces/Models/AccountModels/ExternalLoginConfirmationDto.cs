using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models.AccountModels
{
    public class ExternalLoginConfirmationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
