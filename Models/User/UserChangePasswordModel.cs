﻿using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.User
{
    public class UserChangePasswordModel
    {
        [Required] public string OldPassword { get; set; }

        [Required]
        [MinLength(12, ErrorMessage = "Password length must be greater than 12 characters")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string RepeatPassword { get; set; }
    }
}