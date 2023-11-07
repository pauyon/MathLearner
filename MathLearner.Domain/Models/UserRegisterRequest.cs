﻿using System.ComponentModel.DataAnnotations;

namespace MathLearner.Domain.Models
{
    public class UserRegisterRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
