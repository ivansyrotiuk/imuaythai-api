using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models.AccountModels
{
    public class ExternalLoginConfirmationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
