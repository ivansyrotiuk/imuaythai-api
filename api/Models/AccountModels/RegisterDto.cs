using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models.AccountModels
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string CallbackUrl { get; set; }
    }

    public class FinishRegisterDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public bool? OwnGym { get; set; }
        public string GymName { get; set; }
        public int CountryId { get; set; }
        public int? InstitutionId { get; set; }
    }

}
