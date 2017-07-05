using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models.AccountModels
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
