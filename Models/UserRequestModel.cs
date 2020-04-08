using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models
{
    public class UserRequestModel
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{12,}$",
            ErrorMessage =
                "Password length must be greater than 12 characters, have at least one letter and at least one number")]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{12,}$",
            ErrorMessage =
                "Password length must be greater than 12 characters, have at least one letter and at least one number")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string RepeatPassword { get; set; }
    }
}